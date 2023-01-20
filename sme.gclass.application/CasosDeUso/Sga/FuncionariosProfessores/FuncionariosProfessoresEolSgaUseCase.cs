using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces.Sga.FuncionariosProfessores;
using SME.GoogleClassroom.Aplicacao.Queries.Sga.ObterPerfilUsuario;
using SME.GoogleClassroom.Aplicacao.Queries.UE.ObterTipoDaUe;
using SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Funcionarios.ObterFuncionarioEolPorUeAnoLetivo;
using SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Funcionarios.ObterFuncionarioExternoEolSgaPorUeAnoLetivo;
using SME.GoogleClassroom.Infra.Dtos.Gsa;
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
            var tiposEscolasParceirasLiceu = new List<int>() { 11, 12, 32, 33 };

            IEnumerable<FuncionarioSgaDto> funcionario;
            var tipoEscola = await mediator.Send(new ObterTipoDaEscolaQuery(codigoEscola));

            var escolaCieja = tipoEscola == (int)TipoEscola.Cieja;
            var ehFuncionarioExterno = tiposEscolasParceirasLiceu.Contains(tipoEscola);

            if (!ehFuncionarioExterno)
                funcionario = await mediator.Send(new ObterFuncionarioEolPorUeAnoLetivoQuery(codigoEscola, anoLetivo, escolaCieja));
            else
                funcionario = await mediator.Send(new ObterFuncionarioExternoEolSgaPorUeAnoLetivoQuery(codigoEscola, anoLetivo));

            //Obter Professores - será feito em outr estoria

            return await MapearRetorno(funcionario.ToList(), ehFuncionarioExterno);
        }

        private async Task<ProfessoresFuncionariosSgaDto> MapearRetorno(List<FuncionarioSgaDto> funcionarioSgaDtos, bool ehFuncionarioExterno)
        {
            var retorno = new ProfessoresFuncionariosSgaDto();

            var listaPerfis = ehFuncionarioExterno ? funcionarioSgaDtos.Select(x => x.Funcao).Distinct().ToArray() : funcionarioSgaDtos.Select(x => int.Parse(x.CodCargo)).Distinct().ToArray();

            var obterListaDePerfils = (await mediator.Send(new ObterPerfilFuncionarioQuery(listaPerfis,ehFuncionarioExterno))).ToList();

            MapearFuncionarios(funcionarioSgaDtos, retorno, obterListaDePerfils.ToList(), ehFuncionarioExterno);



            return retorno;
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