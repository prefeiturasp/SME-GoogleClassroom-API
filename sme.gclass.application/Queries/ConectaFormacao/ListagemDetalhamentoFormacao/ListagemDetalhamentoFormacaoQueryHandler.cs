

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

        public ListagemDetalhamentoFormacaoQueryHandler(IRepositorioConectaFormacao repositorioConectaFormacao, IRepositorioProfessorEol repositorioProfessorEol)
        {
            this.repositorioConectaFormacao = repositorioConectaFormacao ?? throw new ArgumentNullException(nameof(repositorioConectaFormacao));
            this.repositorioProfessorEol = repositorioProfessorEol ?? throw new ArgumentNullException(nameof(repositorioProfessorEol));
        }

        public async Task<IEnumerable<FormacaoDetalhaDTO>> Handle(ListagemDetalhamentoFormacaoQuery request, CancellationToken cancellationToken)
        {
            var formacoes = await repositorioConectaFormacao.ListagemFormacoesPorAno(request.Ano);

            if (formacoes.NaoPossuiElementos())
                return default;

            var codigoFormacoes = formacoes.Select(s => s.Codigo).Distinct().ToArray();

            var turmas = await repositorioConectaFormacao.ListagemTurmasPorCodigosFormacoes(codigoFormacoes);
            var professoresRegentes = await repositorioConectaFormacao.ListagemProfessoresRegentesPorCodigosFormacoes(codigoFormacoes);
            var professoresTutores = await repositorioConectaFormacao.ListagemProfessoresTutoresPorCodigosFormacoes(codigoFormacoes);

            var professoresRegentesTutores = professoresRegentes.Union(professoresTutores);

            var cpfsDosProfessores = await repositorioProfessorEol.ObterCpfNomeCompletoPorRegistroFuncional(professoresRegentesTutores.Select(s => s.Rf).ToArray());

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
                    var professoresTurma = professoresRegentesTutores.Where(p => p.CodigoTurma == turma.Codigo)
                        .Select(s => new FormacaoDetalhaTurmaProfessoresDTO()
                        {
                            Rf = s.Rf,
                            Cpf = s.Cpf.EstaPreenchido() ? s.Cpf : cpfsDosProfessores?.FirstOrDefault(c => c.Rf.Equals(s.Rf))?.Cpf,
                            Nome = s.Nome,
                            //Email = s.Email,
                            Tutor = s.Tutor
                        });

                    formacaoDetalhada.AdicionarTurma(turma.Codigo, turma.Nome, professoresTurma);
                }

                retorno.Add(formacaoDetalhada);
            }

            return retorno;
        }
    }
}