using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces.Sga.FuncionariosProfessores;
using SME.GoogleClassroom.Aplicacao.Queries.Sga.ObterDadosProfessoresPorRfs;
using SME.GoogleClassroom.Aplicacao.Queries.Sga.ObterPerfilUsuario;
using SME.GoogleClassroom.Aplicacao.Queries.Sga.ObterProfessorCjSgp;
using SME.GoogleClassroom.Aplicacao.Queries.SME.Pedagogico.Service.Queries;
using SME.GoogleClassroom.Aplicacao.Queries.UE.ObterTipoDaUe;
using SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Funcionarios.ObterFuncionarioEolPorUeAnoLetivo;
using SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Funcionarios.ObterFuncionarioExternoEolSgaPorUeAnoLetivo;
using SME.GoogleClassroom.Dominio.Enumerados;
using SME.GoogleClassroom.Dominio.Extensoes;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Gsa;
using SME.GoogleClassroom.Infra.Dtos.Sga;
using SME.GoogleClassroom.Infra.Enumeradores;

namespace SME.GoogleClassroom.Aplicacao.Sga.FuncionariosProfessores
{
    public class FuncionariosProfessoresEolSgaUseCase : IFuncionariosProfessoresEolSgaUseCase
    {
        private readonly IMediator mediator;

        public FuncionariosProfessoresEolSgaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ProfessoresFuncionariosSgaDto> Executar(int anoLetivo, string codigoEscola)
        {
            var tiposEscolasParceirasLiceu = new List<int>() {11, 12, 32, 33};

            IEnumerable<FuncionarioSgaDto> funcionario;
            var tipoEscola = await mediator.Send(new ObterTipoDaEscolaQuery(codigoEscola));

            var escolaCieja = tipoEscola == (int) TipoEscola.Cieja;
            var ehFuncionarioExterno = tiposEscolasParceirasLiceu.Contains(tipoEscola);

            if (!ehFuncionarioExterno)
                funcionario = await mediator.Send(new ObterFuncionarioEolPorUeAnoLetivoQuery(codigoEscola, anoLetivo, escolaCieja));
            else
                funcionario = await mediator.Send(new ObterFuncionarioExternoEolSgaPorUeAnoLetivoQuery(codigoEscola, anoLetivo));

            var rfsProfessoresCjSgp = (await mediator.Send(new ObterProfessorCjSgpQuery(anoLetivo, codigoEscola))).ToList();
            var listaTurmas = (await mediator.Send(new ObterTurmasPorUeAnoLetivoQuery(codigoEscola, anoLetivo))).ToList();

            return await MapearRetorno(funcionario.ToList(), listaTurmas, ehFuncionarioExterno, rfsProfessoresCjSgp);
        }

        private async Task<ProfessoresFuncionariosSgaDto> MapearRetorno(List<FuncionarioSgaDto> funcionarioSgaDtos, List<Infra.TurmaComponentesDto> listaTurmas, bool ehFuncionarioExterno, List<ProfessorCjSgpDto> rfsProfessoresCjSgp)
        {
            var retorno = new ProfessoresFuncionariosSgaDto();

            var listaPerfis = ehFuncionarioExterno ? funcionarioSgaDtos.Select(x => x.Funcao).Distinct().ToArray() : funcionarioSgaDtos.Select(x => int.Parse(x.CodCargo)).Distinct().ToArray();

            var obterListaDePerfils = (await mediator.Send(new ObterPerfilFuncionarioQuery(listaPerfis, ehFuncionarioExterno))).ToList();

            MapearFuncionarios(funcionarioSgaDtos, retorno, obterListaDePerfils.ToList(), ehFuncionarioExterno);

            await MapearTurmas(listaTurmas, retorno, rfsProfessoresCjSgp);

            return retorno;
        }

        private async Task MapearTurmas(List<TurmaComponentesDto> listaTurmas, ProfessoresFuncionariosSgaDto retorno, List<ProfessorCjSgpDto> rfsProfessoresCjSgp)
        {
            var modalidades = new List<ModalidadeEolSgaDto>();
            var listaProfessoresEol = new List<DadosProfessorEolSgaDto>();
            var listaProfessoresCj = new List<DadosProfessorEolSgaDto>();

            var listaModalidades = listaTurmas.Select(x => (Modalidade) x.Modalidade).ToList().Distinct();

            foreach (var modalidade in listaModalidades)
            {
                var turmas = new List<TurmaEolGsaDto>();
                foreach (var turma in listaTurmas.Where(x => x.Modalidade == (int) modalidade))
                {
                    var modalidadeTurma = (Modalidade) turma.Modalidade;
                    var componentes = new List<ComponeteCurricularEolSgaDto>();

                    var rfProfessoresEol = (turma.Componentes.Select(c => c.RegistroFuncional).Where(w => w != null).Distinct()).ToList();
                    var rfCjTurma = ((rfsProfessoresCjSgp.Where(x => int.Parse(x.TurmaId) == turma.CodigoTurma).Select(s => s.ProfessorRf)).Distinct()).ToList();

                    if (rfProfessoresEol.Any())
                        listaProfessoresEol = (await mediator.Send(new ObterDadosProfessoresPorRfsQuery(rfProfessoresEol.ToArray()))).ToList();

                    if (rfCjTurma.Any())
                        listaProfessoresCj = (await mediator.Send(new ObterDadosProfessoresPorRfsQuery(rfCjTurma.ToArray()))).ToList();

                    foreach (var componente in turma.Componentes)
                    {
                        var professores = new List<ProfessorEolSgaDto>();

                        foreach (var professor in listaProfessoresEol)
                        {
                            professores.Add(new ProfessorEolSgaDto
                            {
                                Cpf = professor.Cpf,
                                NomeCompleto = professor.NomeCompleto,
                                Rf = professor.Rf,
                                Substituto = false
                            });
                        }

                        foreach (var professor in listaProfessoresCj)
                        {
                            professores.Add(new ProfessorEolSgaDto
                            {
                                Cpf = professor.Cpf,
                                NomeCompleto = professor.NomeCompleto,
                                Rf = professor.Rf,
                                Substituto = true
                            });
                        }

                        var rfProfessor = componente.RegistroFuncional;
                        componentes.Add(new ComponeteCurricularEolSgaDto
                        {
                            Descricao = componente.NomeComponenteCurricular,
                            ComponenteCodigo = componente.ComponenteCurricularCodigo,
                            Professores = professores
                        });
                    }

                    turmas.Add(new TurmaEolGsaDto
                    {
                        TurmaCodigo = turma.CodigoTurma,
                        TumaAnoModalidade = turma.AnoTurma?.Trim().Length > 0 ? (modalidadeTurma.ShortName() + turma.AnoTurma) : string.Empty,
                        NomeAno = turma.AnoTurma?.Trim().Length > 0 ? (turma.AnoTurma == "0" ? turma.AnoTurma : turma.AnoTurma + "º ano") : string.Empty,
                        TumaModalidade = modalidadeTurma.ShortName() + turma.NomeTurma,
                        TurmaNome = turma.NomeTurma,
                        ComponentesCurriculares = componentes
                    });
                }

                modalidades.Add(new ModalidadeEolSgaDto
                {
                    NomeModalidade = modalidade.Name(),
                    Turmas = turmas
                });
                ;
            }

            retorno.Modalidades = modalidades;
        }

        private void MapearFuncionarios(IEnumerable<FuncionarioSgaDto> funcionarioSgaDtos, ProfessoresFuncionariosSgaDto retorno, List<PerfilFuncionarioSgaDto> perfilFuncionarioSgaDtos, bool ehFuncionarioExterno)
        {
            var funcionarios = new List<FuncionarioEolSgaDto>();
            foreach (var funcionario in funcionarioSgaDtos)
            {
                funcionarios.Add(new FuncionarioEolSgaDto
                {
                    NomeCompleto = funcionario.NomeCompleto,
                    Rf = funcionario.Rf,
                    Cpf = funcionario.Cpf,
                    Perfil = ehFuncionarioExterno ? perfilFuncionarioSgaDtos!.FirstOrDefault(x => x.Codigo == funcionario.Funcao)!.Perfil : perfilFuncionarioSgaDtos!.FirstOrDefault(x => x.Codigo == int.Parse(funcionario.CodCargo))!.Perfil
                });
            }

            retorno.Funcionarios = funcionarios;
        }
    }
}