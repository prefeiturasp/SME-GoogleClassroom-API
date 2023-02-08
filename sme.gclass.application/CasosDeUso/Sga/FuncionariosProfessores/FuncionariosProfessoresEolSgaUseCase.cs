﻿using System;
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

            return await MapearRetorno(funcionario.ToList(), listaTurmas, ehFuncionarioExterno, rfsProfessoresCjSgp,escolaCieja);
        }

        private async Task<ProfessoresFuncionariosSgaDto> MapearRetorno(List<FuncionarioSgaDto> funcionarioSgaDtos, List<TurmaComponentesDto> listaTurmas, bool ehFuncionarioExterno, List<ProfessorCjSgpDto> rfsProfessoresCjSgp, bool escolaCieja)
        {
            var retorno = new ProfessoresFuncionariosSgaDto();

            var listaPerfis = ehFuncionarioExterno || escolaCieja ? funcionarioSgaDtos.Select(x => x.Funcao).Distinct().ToArray() : funcionarioSgaDtos.Select(x => int.Parse(x.CodCargo)).Distinct().ToArray();

            var obterListaDePerfils = listaPerfis.Length >0 ? (await mediator.Send(new ObterPerfilFuncionarioQuery(listaPerfis, ehFuncionarioExterno))).ToList() 
                                                                                           : new List<PerfilFuncionarioSgaDto>();

            MapearFuncionarios(funcionarioSgaDtos, retorno, obterListaDePerfils.ToList(), ehFuncionarioExterno, escolaCieja);

            await MapearTurmas(listaTurmas, retorno, rfsProfessoresCjSgp);

            return retorno;
        }

        private async Task MapearTurmas(List<TurmaComponentesDto> listaTurmas, ProfessoresFuncionariosSgaDto retorno, List<ProfessorCjSgpDto> rfsProfessoresCjSgp)
        {
            var modalidades = new List<ModalidadeEolSgaDto>();


            var listaModalidades = listaTurmas.Select(x => (Modalidade) x.Modalidade).ToList().Distinct();

            foreach (var modalidade in listaModalidades)
            {
                var turmas = new List<TurmaEolGsaDto>();
                foreach (var turma in listaTurmas.Where(x => x.Modalidade == (int) modalidade))
                {
                    var modalidadeTurma = (Modalidade) turma.Modalidade;
                    var componentes = new List<ComponeteCurricularEolSgaDto>();


                    foreach (var componente in turma.Componentes)
                    {
                        var listaProfessoresEol = new List<DadosProfessorEolSgaDto>();
                        var listaProfessoresCj = new List<DadosProfessorEolSgaDto>();

                        var rfProfessoresEol = (turma.Componentes.Where(c => c.ComponenteCurricularCodigo == componente.ComponenteCurricularCodigo).Select(c => c.RegistroFuncional).Where(w => w != null).Distinct()).ToList();

                        string codigoComponente = componente.ComponenteCurricularCodigo.ToString();
                        
                        var rfCjTurma = ((rfsProfessoresCjSgp.Where(x => int.Parse(x.TurmaId) == turma.CodigoTurma && x.Disciplinas.ToList().Contains(codigoComponente)).Select(s => s.ProfessorRf)).Distinct()).ToList();

                        if (rfProfessoresEol.Any())
                            listaProfessoresEol = (await mediator.Send(new ObterDadosProfessoresPorRfsQuery(rfProfessoresEol.ToArray()))).ToList();

                        if (rfCjTurma.Any())
                            listaProfessoresCj = (await mediator.Send(new ObterDadosProfessoresPorRfsQuery(rfCjTurma.ToArray()))).ToList();



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
                        TurmaAnoModalidade = turma.AnoTurma?.Trim().Length > 0 ? (modalidadeTurma.ShortName() + turma.AnoTurma) : string.Empty,
                        NomeAno = turma.AnoTurma?.Trim().Length > 0 ? (turma.AnoTurma == "0" ? turma.AnoTurma : turma.AnoTurma + "º ano") : string.Empty,
                        TurmaModalidade = modalidadeTurma.ShortName() + turma.NomeTurma,
                        TurmaNome = turma.NomeTurma,
                        ComponentesCurriculares = componentes,
                        ComplementoTurma = turma.NomeFiltro,
                    });
                }

                modalidades.Add(new ModalidadeEolSgaDto
                {
                    NomeModalidade = modalidade.Name(),
                    IdModalidade = (int)modalidade,
                    SiglaModalidade = modalidade.ShortName(),
                    Turmas = turmas
                });
            }

            retorno.Modalidades = modalidades;
        }

        private void MapearFuncionarios(IEnumerable<FuncionarioSgaDto> funcionarioSgaDtos, ProfessoresFuncionariosSgaDto retorno, List<PerfilFuncionarioSgaDto> perfilFuncionarioSgaDtos, bool ehFuncionarioExterno,bool escolaCieja)
        {
            var funcionarios = new List<FuncionarioEolSgaDto>();
            foreach (var funcionario in funcionarioSgaDtos)
            {
                string perfil = escolaCieja ? ObterDescricaoPerfilCieja(funcionario.Funcao) : ObterDescricaoPerfil(perfilFuncionarioSgaDtos, ehFuncionarioExterno,funcionario);
                funcionarios.Add(new FuncionarioEolSgaDto
                {
                    NomeCompleto = funcionario.NomeCompleto,
                    Rf = funcionario.Rf,
                    Cpf = funcionario.Cpf,
                    Perfil = perfil
                });
            }

            retorno.Funcionarios = funcionarios;
        }

        private static string ObterDescricaoPerfil(List<PerfilFuncionarioSgaDto> perfilFuncionarioSgaDtos, bool ehFuncionarioExterno, FuncionarioSgaDto funcionario)
        {
            return perfilFuncionarioSgaDtos.Any() ? ehFuncionarioExterno 
                                                  ? perfilFuncionarioSgaDtos?.FirstOrDefault(x => x.Codigo == funcionario.Funcao)?.Perfil 
                                                  : perfilFuncionarioSgaDtos?.FirstOrDefault(x => x.Codigo == int.Parse(funcionario.CodCargo))?.Perfil 
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