

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Dominio.SME.CDEP.Dominio.Extensions;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ListagemDetalhamentoFormacaoQueryHandler : IRequestHandler<ListagemDetalhamentoFormacaoQuery, IEnumerable<FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO>>
    {
        private readonly IRepositorioConectaFormacao repositorioConectaFormacao;
        private readonly IRepositorioProfessorEol repositorioProfessorEol;
        private readonly IRepositorioUsuario repositorioUsuario;

        public ListagemDetalhamentoFormacaoQueryHandler(IRepositorioConectaFormacao repositorioConectaFormacao, IRepositorioProfessorEol repositorioProfessorEol, IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioConectaFormacao = repositorioConectaFormacao ?? throw new ArgumentNullException(nameof(repositorioConectaFormacao));
            this.repositorioProfessorEol = repositorioProfessorEol ?? throw new ArgumentNullException(nameof(repositorioProfessorEol));
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<IEnumerable<FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO>> Handle(ListagemDetalhamentoFormacaoQuery request, CancellationToken cancellationToken)
        {
            var formacoes = await repositorioConectaFormacao.ListagemFormacoesPorAno(request.Ano);

            if (formacoes.NaoPossuiElementos())
                return default;

            var codigosDasTurmas = formacoes.Select(s => s.CodigoFormacao).Distinct().ToArray();

            var turmas = await repositorioConectaFormacao.ListagemTurmasPorCodigosFormacoes(codigosDasTurmas);
            
            var professoresRegentes = await repositorioConectaFormacao.ListagemProfessoresRegentesPorCodigosFormacoes(codigosDasTurmas);
            
            var professoresTutores = await repositorioConectaFormacao.ListagemProfessoresTutoresPorCodigosFormacoes(codigosDasTurmas);

            var professoresRegentesTutores = professoresRegentes.Union(professoresTutores);

            var usuariosProfessores = await repositorioUsuario.ObterUsuariosGooglePorCodigos(professoresRegentesTutores.Select(t => long.Parse(t.Rf)).Distinct().ToArray(), new[] { 2, 3 });

            var cpfsDosProfessores = await repositorioProfessorEol.ObterCpfNomeCompletoPorRegistroFuncional(professoresRegentesTutores.Select(s=> s.Rf).ToArray());

            var detalhamentosDasFormacoes = formacoes.Select(f => new FormacaoCodigoNomeDataRealizacaoCoordenadoriaTurmasDTO()
            {
                CodigoFormacao = f.CodigoFormacao,
                NomeFormacao = f.NomeFormacao,
                Coordenadoria = f.Coordenadoria,
                DataRealizacaoInicio = f.DataRealizacaoInicio,
                DataRealizacaoFim = f.DataRealizacaoFim,
                Turmas = turmas.Where(w=> w.CodigoFormacao == f.CodigoFormacao)
                    .Select(t => new CodigoNomeTurmaProfessoresDTO()
                    {
                        CodigoTurma = t.CodigoTurma,
                        NomeTurma = t.NomeTurma,
                        Professores = professoresRegentesTutores.Where(p=> p.CodigoTurma == t.CodigoTurma)
                            .Select(s => new ProfessorRfCpfNomeEmailTutorDTO()
                        {
                            Rf = s.Rf,
                            Cpf = s.Cpf.EstaPreenchido() ? s.Cpf : cpfsDosProfessores?.FirstOrDefault(c=> c.Rf.Equals(s.Rf))?.Cpf,
                            Nome = s.Nome,
                            Email = usuariosProfessores.FirstOrDefault(t => t.Id == s.Rf)?.Email,
                            Tutor = s.Tutor
                        })
                    })
            });
            
            return detalhamentosDasFormacoes;
        }
    }
}