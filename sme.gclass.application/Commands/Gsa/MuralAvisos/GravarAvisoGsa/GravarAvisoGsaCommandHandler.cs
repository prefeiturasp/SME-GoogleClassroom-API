using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class GravarAvisoGsaCommandHandler : AsyncRequestHandler<GravarAvisoGsaCommand>
    {
        private readonly IRepositorioAviso repositorioAviso;
        private readonly IMediator mediator;

        public GravarAvisoGsaCommandHandler(IRepositorioAviso repositorioAviso, IMediator mediator)
        {
            this.repositorioAviso = repositorioAviso ?? throw new System.ArgumentNullException(nameof(repositorioAviso));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override async Task Handle(GravarAvisoGsaCommand request, CancellationToken cancellationToken)
        {
            var usuarioId = await ObterUsuarioId(request.AvisoDto.UsuarioClassroomId);

            var avisoGsa = MapearEntidade(request.AvisoDto.Id, request.AvisoDto.Mensagem, usuarioId, request.AvisoDto.CursoId, request.AvisoDto.CriadoEm, request.AvisoDto.AlteradoEm);

            if (await RegistroExistente(request.AvisoDto.Id))
                await repositorioAviso.AlterarAviso(avisoGsa);
            else
                await repositorioAviso.InserirAviso(avisoGsa);
        }

        private async Task<long> ObterUsuarioId(string usuarioClassroomId)
        {
            var usuarioId = await mediator.Send(new ObterUsuarioIdPorClassroomIdQuery(usuarioClassroomId));
            if (usuarioId == 0)
                throw new NegocioException("ID do usuário não localizado na base GCA para gravação do aviso do mural");

            return usuarioId;
        }

        private AvisoGsa MapearEntidade(long id, string mensagem, long usuarioId, long cursoId, DateTime criadoEm, DateTime alteradoEm)
            => new Dominio.AvisoGsa(id,
                                    mensagem,
                                    usuarioId,
                                    cursoId,
                                    criadoEm,
                                    alteradoEm);

        private async Task<bool> RegistroExistente(long id)
            => await repositorioAviso.RegistroExiste(id);
    }
}
