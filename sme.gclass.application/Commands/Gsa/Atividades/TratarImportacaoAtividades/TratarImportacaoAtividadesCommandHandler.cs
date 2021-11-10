using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarImportacaoAtividadesCommandHandler : AsyncRequestHandler<TratarImportacaoAtividadesCommand>
    {
        private readonly IMediator mediator;

        public TratarImportacaoAtividadesCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override async Task Handle(TratarImportacaoAtividadesCommand request, CancellationToken cancellationToken)
        {

            if (request.Atividades.Any())
            {
                //var atividadesImportar = ObterAtividadesInclusasOuAlteradas(request.Atividades, request.UltimaExecucao);
                var atividadesImportar = request.Atividades;


                var atividadesIdsImportar = atividadesImportar.Select(a => a.Id).ToList();


                //--> Usuários
                var usuariosIds = atividadesImportar.Select(a => a.UsuarioClassroomId).Distinct().ToList();
                var usuariosParaIntegracao = await mediator.Send(new ObterUsuariosPorClassroomIdsQuery(usuariosIds));

                //Excluir todas as atividades;
                await mediator.Send(new ExcluirAtividadesPorIdsCommand(atividadesIdsImportar));

                var atividadesParaPersistir = atividadesImportar.Where( at => usuariosParaIntegracao.Select(us => us.GoogleClassroomId).Contains(at.UsuarioClassroomId)).Select(a => MapearEntidade(a, usuariosParaIntegracao)).ToList();

                //Incluir Todas
                await mediator.Send(new IncluirAtividadesBulkCommand(atividadesParaPersistir));


                //----> Enviar para o SGP

                //--> Cursos
                var cursosIds = atividadesImportar.Select(a => a.CursoId).Distinct().ToList();
                var cursosParaIntegracao = await mediator.Send(new ObterCursosPorIdsParaIntegracaoQuery(cursosIds));



                await EnviarParaSgp(request.Atividades, usuariosParaIntegracao, cursosParaIntegracao);
            }
        }
        private async Task EnviarParaSgp(IEnumerable<AtividadeGsaDto> atividadesGsa, IEnumerable<UsuarioGoogleDto> usuariosParaIntegracao, IEnumerable<CursoGoogleDtoParaIntegracao> cursosParaIntegracao)
        {
            foreach (var atividadeGsa in atividadesGsa)
            {

                var cursoParaIntegracao = cursosParaIntegracao.FirstOrDefault(a => a.CursoId == atividadeGsa.CursoId);
                if (cursoParaIntegracao == null) continue;

                var usuarioParaIntegracao = usuariosParaIntegracao.FirstOrDefault(a => a.GoogleClassroomId == atividadeGsa.UsuarioClassroomId);
                if (usuarioParaIntegracao == null) continue;

                var avisoDto = new AtividadeIntegracaoSgpDto()
                {
                    AtividadeClassroomId = atividadeGsa.Id,
                    TurmaId = cursoParaIntegracao.TurmaId.ToString(),
                    ComponenteCurricularId = cursoParaIntegracao.ComponenteCurricularId,
                    UsuarioRf = usuarioParaIntegracao.Id.ToString(),
                    Titulo = atividadeGsa.Titulo,
                    Descricao = string.IsNullOrEmpty(atividadeGsa.Descricao?.Trim()) ? atividadeGsa.Titulo : atividadeGsa.Descricao,
                    DataCriacao = atividadeGsa.CriadoEm,
                    DataAlteracao = atividadeGsa.AlteradoEm,
                };

                await mediator.Send(new PublicaFilaRabbitSgpCommand(RotasRabbitSgp.RotaAtividadesSync, avisoDto, usuarioParaIntegracao.Id.ToString(), usuarioParaIntegracao.Nome));
            }

        }
        private IEnumerable<AtividadeGsaDto> ObterAtividadesInclusasOuAlteradas(ICollection<AtividadeGsaDto> atividades, DateTime ultimaExecucao)
            => atividades.Where(a => a.CriadoEm > ultimaExecucao
                                  || a.AlteradoEm > ultimaExecucao);

        private AtividadeGsa MapearEntidade(AtividadeGsaDto atividadeGsaDto, IEnumerable<UsuarioGoogleDto> usuariosGoogle)
          => new Dominio.AtividadeGsa(atividadeGsaDto.Id,
                                  atividadeGsaDto.Titulo,
                                  string.IsNullOrEmpty(atividadeGsaDto.Descricao?.Trim()) ? atividadeGsaDto.Titulo : atividadeGsaDto.Descricao ,
                                  usuariosGoogle.FirstOrDefault(a => a.GoogleClassroomId == atividadeGsaDto.UsuarioClassroomId).Indice,
                                  atividadeGsaDto.CursoId,
                                  atividadeGsaDto.CriadoEm,
                                  atividadeGsaDto.AlteradoEm,
                                  atividadeGsaDto.DataEntrega,
                                  atividadeGsaDto.NotaMaxima);
    }
}
