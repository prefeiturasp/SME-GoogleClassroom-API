using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces.Sga.FuncionariosProfessores;
using SME.GoogleClassroom.Aplicacao.Queries.UE.ObterTipoDaUe;
using SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Funcionarios.ObterFuncionarioEolPorUeAnoLetivo;
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
            var tiposEscolasParceirasLiceu = new List<int>() { 11,12,32,33}; 
            
            IEnumerable<FuncionarioSgaDto> funcionario;
            //Obter o Tipo da UE
            var tipoEscola = await mediator.Send(new ObterTipoDaEscolaQuery(codigoEscola));

            //verificar se Escola é cieja
            var escolaCieja = tipoEscola == (int)TipoEscola.Cieja;
            
            //Obter funcionarios
            if (!tiposEscolasParceirasLiceu.Contains(tipoEscola))
                funcionario = await mediator.Send(new ObterFuncionarioEolPorUeAnoLetivoQuery(codigoEscola, anoLetivo,escolaCieja));
            // else
                //funcionario = await mediator.Send(new ); //onter funcionarios da tabela contratos externos

            return MapearRetorno();
        }

        private ProfessoresFuncionariosSgaDto MapearRetorno()
        {
            return new ProfessoresFuncionariosSgaDto();
        }
    }
}