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
    public class FuncionariosProfessoresEolUseCase : IFuncionariosProfessoresEolUseCase
    {
        private readonly IMediator mediator;
        private const string SUPERVISOR = "SUPERVISOR"; 

        public FuncionariosProfessoresEolUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ProfessoresFuncionariosDto> Executar(int anoLetivo, string codigoEscola)
        {
            var tiposEscolasParceirasLiceu = new List<int>() {11, 12, 32, 33};

            IEnumerable<FuncionarioDto> funcionario;
            var tipoEscola = await mediator.Send(new ObterTipoDaEscolaQuery(codigoEscola));

            var escolaCieja = tipoEscola == (int) TipoEscola.Cieja;
            var ehFuncionarioExterno = tiposEscolasParceirasLiceu.Contains(tipoEscola);

            if (!ehFuncionarioExterno)
                funcionario = await mediator.Send(new ObterFuncionarioEolPorUeAnoLetivoQuery(codigoEscola, anoLetivo, escolaCieja));
            else
                funcionario = await mediator.Send(new ObterFuncionarioExternoEolPorUeAnoLetivoQuery(codigoEscola, anoLetivo));

            var rfsProfessoresCjSgp = (await mediator.Send(new ObterProfessorCjSgpQuery(anoLetivo, codigoEscola))).ToList();
            
            var rfsSupervisoresSgp = (await mediator.Send(new ObterAtribuicaoResponsaveisSgpQuery((int)TipoResponsavelAtribuicao.SupervisorEscolar,codigoEscola))).ToList();
            
            var listaTurmas = (await mediator.Send(new ObterTurmasPorUeAnoLetivoQuery(codigoEscola, anoLetivo))).ToList();

            return await MapearRetorno(funcionario.ToList(), listaTurmas, ehFuncionarioExterno, rfsProfessoresCjSgp,escolaCieja,rfsSupervisoresSgp);
        }

        private async Task<ProfessoresFuncionariosDto> MapearRetorno(List<FuncionarioDto> funcionarioDtos, List<TurmaComponentesDto> listaTurmas, bool ehFuncionarioExterno, List<ProfessorCjSgpDto> rfsProfessoresCjSgp, bool escolaCieja, List<ResponsaveisSgpDto> responsaveisSgp)
        {
            var retorno = new ProfessoresFuncionariosDto();

            var listaPerfis = ehFuncionarioExterno || escolaCieja ? funcionarioDtos.Select(x => x.Funcao).Distinct().ToArray() : funcionarioDtos.Select(x => int.Parse(x.CodCargo)).Distinct().ToArray();

            var obterListaDePerfils = listaPerfis.Length >0 ? (await mediator.Send(new ObterPerfilFuncionarioQuery(listaPerfis, ehFuncionarioExterno))).ToList() 
                                                                                           : new List<PerfilFuncionarioDto>();

            await MapearFuncionarios(funcionarioDtos, retorno, obterListaDePerfils.ToList(), ehFuncionarioExterno, escolaCieja, responsaveisSgp);

            await MapearTurmas(listaTurmas, retorno, rfsProfessoresCjSgp);

            return retorno;
        }

        private async Task<List<DadosProfessorEolDto>> ObterListaRegistroFuncional(List<TurmaComponentesDto> listaTurmas)
        {
            var professoresEol   = new List<DadosProfessorEolDto>();
            var listaModalidades = listaTurmas.Select(x => (Modalidade) x.Modalidade).ToList().Distinct();
            var listaTurmaComponentes = listaTurmas.Where(x => listaModalidades.Contains((Modalidade) x.Modalidade)).ToList();
            var listaComponentes = new List<ComponenteTurmaDto>();
            listaTurmaComponentes?.ForEach(x => listaComponentes?.AddRange(x.Componentes));
            var listaRegistroFuncional = listaComponentes?.Select(x => x.RegistroFuncional).Where(r => r != null).Distinct().ToArray();
            if (listaRegistroFuncional.Any())
                professoresEol = (await mediator.Send(new ObterDadosProfessoresPorRfsQuery(listaRegistroFuncional))).ToList();

            return professoresEol;
        }

        private async Task<List<DadosProfessorEolDto>> ObterListaRegistroProfessorCj(List<ProfessorCjSgpDto> rfsProfessoresCjSgp)
        {
            var professoresCj = new List<DadosProfessorEolDto>();
            var listaProfessoresCjSgp = rfsProfessoresCjSgp.Select(x => x.ProfessorRf).Distinct().ToArray();
            if (listaProfessoresCjSgp.Any())
                professoresCj = (await mediator.Send(new ObterDadosProfessoresPorRfsQuery(listaProfessoresCjSgp))).ToList();
            
            return professoresCj;
        }

        private async Task<List<DadosProfessorEolDto>> ObterListaRegistroSupervisor(List<ResponsaveisSgpDto> responsaveisSgp)
        {
            var retorno = new List<DadosProfessorEolDto>();
            var supervisores = responsaveisSgp.Select(x => x.CodigoRF).Distinct().ToArray();
            if (supervisores.Any())
                retorno = (await mediator.Send(new ObterDadosProfessoresPorRfsQuery(supervisores))).ToList();

            return retorno;
        }

        private async Task MapearTurmas(List<TurmaComponentesDto> listaTurmas, ProfessoresFuncionariosDto retorno, List<ProfessorCjSgpDto> rfsProfessoresCjSgp)
        {
            var modalidades = new List<ModalidadeEolDto>();

            var listaModalidades = listaTurmas.Select(x => (Modalidade) x.Modalidade).ToList().Distinct();

             var professoresEol   = await ObterListaRegistroFuncional(listaTurmas);
             var professoresCj = await ObterListaRegistroProfessorCj(rfsProfessoresCjSgp);
            
            foreach (var modalidade in listaModalidades)
            {
                var turmas = new List<TurmaEolGsaDto>();
                foreach (var turma in listaTurmas.Where(x => x.Modalidade == (int) modalidade))
                {
                    var modalidadeTurma = (Modalidade) turma.Modalidade;
                    var componentes = new List<ComponeteCurricularEolDto>();

                    foreach (var componente in turma.Componentes)
                    {
                        var listaProfessoresEol = new List<DadosProfessorEolDto>();
                        var listaProfessoresCj = new List<DadosProfessorEolDto>();

                        var rfProfessoresEol = (turma.Componentes.Where(c => c.ComponenteCurricularCodigo == componente.ComponenteCurricularCodigo).Select(c => c.RegistroFuncional).Where(w => w != null).Distinct()).ToList();
                       
                        var rfCjTurma = ((rfsProfessoresCjSgp.Where(x => int.Parse(x.TurmaId) == turma.CodigoTurma && x.DisciplinasId.Contains(componente.ComponenteCurricularCodigo)).Select(s => s.ProfessorRf)).Distinct()).ToList();

                        if (rfProfessoresEol.Any())
                            listaProfessoresEol = professoresEol?.Where(r => rfProfessoresEol.Contains(r.Rf)).ToList();

                        if (rfCjTurma.Any())
                            listaProfessoresCj = professoresCj?.Where(x => rfCjTurma.Contains(x.Rf)).ToList() ;

                        var professores = new List<ProfessorEolDto>();

                        foreach (var professor in listaProfessoresEol)
                        {
                            professores.Add(new ProfessorEolDto
                            {
                                Cpf = professor.Cpf,
                                NomeCompleto = professor.NomeCompleto,
                                Rf = professor.Rf,
                                Substituto = false
                            });
                        }

                        foreach (var professor in listaProfessoresCj)
                        {
                            professores.Add(new ProfessorEolDto
                            {
                                Cpf = professor.Cpf,
                                NomeCompleto = professor.NomeCompleto,
                                Rf = professor.Rf,
                                Substituto = true
                            });
                        }

                        componentes.Add(new ComponeteCurricularEolDto
                        {
                            Descricao = componente.NomeComponenteCurricular,
                            ComponenteCodigo = componente.ComponenteCurricularCodigo.ToString(),
                            Professores = professores
                        });
                    }

                    turmas.Add(new TurmaEolGsaDto
                    {
                        TurmaCodigo = turma.CodigoTurma,
                        TurmaAnoModalidade = turma.AnoTurma?.Trim().Length > 0 ? (modalidadeTurma.ShortName() + turma.AnoTurma) : string.Empty,
                        NomeAno = turma.AnoTurma?.Trim().Length > 0 ? (turma.AnoTurma == "0" ? turma.AnoTurma : turma.AnoTurma + "º ano") : string.Empty,
                        TurmaModalidade = modalidadeTurma.ShortName() + turma.NomeTurma,
                        TurmaNome = turma.NomeTurma,
                        ComponentesCurriculares = componentes,
                        ComplementoTurma = turma.NomeFiltro,
                    });
                }

                modalidades.Add(new ModalidadeEolDto
                {
                    NomeModalidade = modalidade.Name(),
                    IdModalidade = (int)modalidade,
                    SiglaModalidade = modalidade.ShortName(),
                    Turmas = turmas
                });
            }

            retorno.Modalidades = modalidades;
        }

        private async Task MapearFuncionarios(IEnumerable<FuncionarioDto> funcionarioDtos, ProfessoresFuncionariosDto retorno, List<PerfilFuncionarioDto> perfilFuncionarioDtos, bool ehFuncionarioExterno,bool escolaCieja, List<ResponsaveisSgpDto> responsaveisSgp)
        {
           var funcionarios = new List<FuncionarioEolDto>();
           foreach (var funcionario in funcionarioDtos)
           {
               var perfil = escolaCieja ? ObterDescricaoPerfilCieja(funcionario.Funcao) : ObterDescricaoPerfil(perfilFuncionarioDtos, ehFuncionarioExterno,funcionario);
               funcionarios.Add(new FuncionarioEolDto
               {
                   NomeCompleto = funcionario.NomeCompleto,
                   Rf = funcionario.Rf,
                   Cpf = funcionario.Cpf,
                   Perfil = perfil
               });
           }

           var supervidoresResponsaveis = await ObterListaRegistroSupervisor(responsaveisSgp);
           foreach (var responsaveis in supervidoresResponsaveis)
           {
               funcionarios.Add(new FuncionarioEolDto
               {
                   NomeCompleto = responsaveis.NomeCompleto,
                   Rf = responsaveis.Rf,
                   Cpf = responsaveis.Cpf,
                   Perfil = SUPERVISOR
               });
           }

           retorno.Funcionarios = funcionarios;
        }

        private static string ObterDescricaoPerfil(List<PerfilFuncionarioDto> perfilFuncionarioDtos, bool ehFuncionarioExterno, FuncionarioDto funcionario)
        {
            return perfilFuncionarioDtos.Any() ? ehFuncionarioExterno 
                                                  ? perfilFuncionarioDtos?.FirstOrDefault(x => x.Codigo == funcionario.Funcao)?.Perfil 
                                                  : perfilFuncionarioDtos?.FirstOrDefault(x => x.Codigo == int.Parse(funcionario.CodCargo))?.Perfil 
                                                  : string.Empty;
        }


        private static string ObterDescricaoPerfilCieja(int funcao)
        {
            var perfil = Enum.GetValues(typeof(CiejaTipoFuncao))
                             .Cast<CiejaTipoFuncao>()
                             .Where(x => (int)x == funcao)?.FirstOrDefault().ShortName();

            return perfil;
        }
    }
}