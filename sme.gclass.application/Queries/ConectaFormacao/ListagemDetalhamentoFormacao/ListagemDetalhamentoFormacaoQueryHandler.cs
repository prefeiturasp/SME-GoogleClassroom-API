using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Dominio.SME.CDEP.Dominio.Extensions;
using SME.GoogleClassroom.Infra.Dtos.ConectaFormacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemDetalhamentoFormacaoQueryHandler : IRequestHandler<ListagemDetalhamentoFormacaoQuery, IEnumerable<FormacaoDetalhaDTO>>
    {
        private readonly IRepositorioConectaFormacao repositorioConectaFormacao;
        private readonly IRepositorioProfessorEol repositorioProfessorEol;
        private readonly IRepositorioUsuario repositorioUsuario;
        private readonly IMediator mediator;

        public ListagemDetalhamentoFormacaoQueryHandler(
            IRepositorioConectaFormacao repositorioConectaFormacao,
            IRepositorioProfessorEol repositorioProfessorEol,
            IRepositorioUsuario repositorioUsuario,
            IMediator mediator)
        {
            this.repositorioConectaFormacao = repositorioConectaFormacao ?? throw new ArgumentNullException(nameof(repositorioConectaFormacao));
            this.repositorioProfessorEol = repositorioProfessorEol ?? throw new ArgumentNullException(nameof(repositorioProfessorEol));
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<FormacaoDetalhaDTO>> Handle(ListagemDetalhamentoFormacaoQuery request, CancellationToken cancellationToken)
        {
            var formacoes = await repositorioConectaFormacao.ListagemFormacoesPorAno(request.Ano, request.AreaPromotoraId);

            if (formacoes.NaoPossuiElementos())
                return default;

            var codigoFormacoes = formacoes.Select(s => s.Codigo).Distinct().ToArray();

            var turmas = await repositorioConectaFormacao.ListagemTurmasPorCodigosFormacoes(codigoFormacoes);
            var professoresRegentes = await repositorioConectaFormacao.ListagemProfessoresRegentesPorCodigosFormacoes(codigoFormacoes);
            var professoresTutores = await repositorioConectaFormacao.ListagemProfessoresTutoresPorCodigosFormacoes(codigoFormacoes);

            var professoresRegentesTutores = professoresRegentes.Union(professoresTutores);

            var rfs = professoresRegentesTutores.Where(t => !string.IsNullOrEmpty(t.Rf)).Select(t => t.Rf).Distinct().ToArray();

            var cpfsDosProfessores = await repositorioProfessorEol.ObterCpfNomeCompletoPorRegistroFuncional(rfs);
            var usuariosProfessores = await repositorioUsuario.ObterUsuariosGooglePorCodigos(rfs.Select(t => long.Parse(t)).ToArray(), new[] { (int)UsuarioTipo.Professor, (int)UsuarioTipo.Funcionario });

            var usuariosProfessoresPorCpf = Enumerable.Empty<UsuarioGoogleDto>();
            var cpfs = professoresRegentesTutores.Where(t => !string.IsNullOrEmpty(t.Cpf)).Select(t => t.Cpf).Distinct().ToArray();
            if (cpfs.PossuiElementos())
                usuariosProfessoresPorCpf = await repositorioUsuario.ObterUsuariosGooglePorCpfs(cpfs, new[] { (int)UsuarioTipo.FuncionarioIndireto });

            var retorno = new List<FormacaoDetalhaDTO>();
            foreach (var formacao in formacoes)
            {
                var formacaoDetalhada = new FormacaoDetalhaDTO(
                    formacao.CodigoAreaPromotora.ToString(),
                    formacao.NomeAreaPromotora,
                    formacao.Ano.ToString(),
                    formacao.Codigo.ToString(),
                    formacao.Nome
                    );

                var turmasFormacao = turmas.Where(w => w.CodigoFormacao == formacao.Codigo);
                foreach (var turma in turmasFormacao)
                {
                    var professoresTurma = new List<FormacaoDetalhaTurmaProfessoresDTO>();
                    foreach (var professorTurma in professoresRegentesTutores.Where(p => p.CodigoTurma == turma.Codigo))
                    {
                        var cpf = professorTurma.Cpf.EstaPreenchido() ? professorTurma.Cpf : cpfsDosProfessores?.FirstOrDefault(c => c.Rf.Equals(professorTurma.Rf))?.Cpf;

                        var email = professorTurma.Rf.EstaPreenchido() ?
                                usuariosProfessores.FirstOrDefault(t => t.Id == professorTurma.Rf)?.Email :
                                usuariosProfessoresPorCpf.FirstOrDefault(f => f.Cpf == professorTurma.Cpf)?.Email;

                        email = !string.IsNullOrEmpty(email) ? email :
                            await mediator.Send(new GerarEmailFuncionarioCommand(professorTurma.Nome, professorTurma.Rf, cpf, !string.IsNullOrEmpty(cpf)), cancellationToken);

                        professoresTurma.Add(new FormacaoDetalhaTurmaProfessoresDTO()
                        {
                            Rf = professorTurma.Rf.NaoEhNulo() ? professorTurma.Rf : cpf,
                            Cpf = cpf,
                            Nome = professorTurma.Nome,
                            Email = email,
                            Tutor = professorTurma.Tutor
                        });
                    }

                    formacaoDetalhada.AdicionarTurma(turma.Codigo, turma.Nome, professoresTurma);
                }

                retorno.Add(formacaoDetalhada);
            }

            return retorno;
        }
    }
}