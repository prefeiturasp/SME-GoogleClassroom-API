using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Dominio.Extensoes;
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

            var professoresRegentesTutores = professoresRegentes
                .Concat(professoresTutores)
                .DistinctBy(p => new { p.CodigoTurma, Rf = p.Rf?.Trim(), Cpf = p.Cpf?.Trim(), p.Tutor })
                .ToList();

            var rfs = professoresRegentesTutores
                .Where(t => !string.IsNullOrWhiteSpace(t.Rf))
                .Select(t => t.Rf.Trim())
                .Distinct()
                .ToArray();

            var cpfsDosProfessores = await repositorioProfessorEol.ObterCpfNomeCompletoPorRegistroFuncional(rfs);

            var rfsValidos = rfs.Where(r => long.TryParse(r, out _)).Select(long.Parse).ToArray();
            var usuariosProfessores = rfsValidos.Any()
                ? await repositorioUsuario.ObterUsuariosGooglePorCodigos(rfsValidos, new[] { (int)UsuarioTipo.Professor, (int)UsuarioTipo.Funcionario })
                : Enumerable.Empty<UsuarioGoogleDto>();

            var usuariosProfessoresPorCpf = Enumerable.Empty<UsuarioGoogleDto>();
            var cpfs = professoresRegentesTutores
                .Where(t => !string.IsNullOrWhiteSpace(t.Cpf))
                .Select(t => t.Cpf.Trim())
                .Distinct()
                .ToArray();

            if (cpfs.PossuiElementos())
                usuariosProfessoresPorCpf = await repositorioUsuario.ObterUsuariosGooglePorCpfs(cpfs, new[] { (int)UsuarioTipo.FuncionarioIndireto });

            var retorno = new List<FormacaoDetalhaDTO>();
            foreach (var formacao in formacoes)
            {
                if (!request.AreaPromotoraId.HasValue)
                {
                    if (formacao.CodigoAreaPromotora != (long)AreaPromotoraTipo.CopedNucleoFormacao)
                        formacao.CodigoAreaPromotora = (long)AreaPromotoraTipo.Emforpef;

                    formacao.NomeAreaPromotora = ((AreaPromotoraTipo)formacao.CodigoAreaPromotora).Name();
                }

                var formacaoDetalhada = new FormacaoDetalhaDTO(
                        formacao.CodigoAreaPromotora.ToString(),
                        formacao.NomeAreaPromotora?.Trim(),
                        formacao.Ano.ToString(),
                        formacao.Codigo.ToString(),
                        formacao.Nome?.Trim()
                        );

                var turmasFormacao = turmas.Where(w => w.CodigoFormacao == formacao.Codigo);
                foreach (var turma in turmasFormacao)
                {
                    var professoresTurma = new List<FormacaoDetalhaTurmaProfessoresDTO>();
                    foreach (var professorTurma in professoresRegentesTutores.Where(p => p.CodigoTurma == turma.Codigo))
                    {
                        var rfTrim = !string.IsNullOrWhiteSpace(professorTurma.Rf) ? professorTurma.Rf.Trim() : null;
                        var cpfTrim = !string.IsNullOrWhiteSpace(professorTurma.Cpf) ? professorTurma.Cpf.Trim() : null;

                        var cpf = cpfTrim.EstaPreenchido()
                            ? cpfTrim
                            : cpfsDosProfessores?.FirstOrDefault(c => c.Rf?.Trim() == rfTrim)?.Cpf?.Trim();

                        string email = null;
                        if (!string.IsNullOrWhiteSpace(rfTrim))
                            email = usuariosProfessores.FirstOrDefault(t => t.Id?.Trim() == rfTrim)?.Email?.Trim();

                        if (string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(cpf))
                            email = usuariosProfessoresPorCpf.FirstOrDefault(f => f.Cpf?.Trim() == cpf)?.Email?.Trim();

                        if (string.IsNullOrWhiteSpace(email))
                        {
                            email = await mediator.Send(new GerarEmailFuncionarioCommand(
                                professorTurma.Nome?.Trim(),
                                rfTrim,
                                cpf,
                                !string.IsNullOrEmpty(cpf)), cancellationToken);
                        }

                        email = email?.Trim();

                        professoresTurma.Add(new FormacaoDetalhaTurmaProfessoresDTO()
                        {
                            Rf = rfTrim,
                            Cpf = cpf,
                            Nome = professorTurma.Nome?.Trim(),
                            Email = email,
                            Tutor = professorTurma.Tutor
                        });
                    }

                    formacaoDetalhada.AdicionarTurma(turma.Codigo, turma.Nome?.Trim(), professoresTurma);
                }

                retorno.Add(formacaoDetalhada);
            }

            return retorno;
        }
    }
}