using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Funcionarios.ObterFuncionarioExternoEolSgaPorUeAnoLetivo
{
    public class ObterFuncionarioExternoEolSgaPorUeAnoLetivoQuery  : IRequest<IEnumerable<FuncionarioSgaDto>>
    {
        public ObterFuncionarioExternoEolSgaPorUeAnoLetivoQuery(string codigoEscola, int anoLetivo)
        {
            CodigoEscola = codigoEscola;
            AnoLetivo = anoLetivo;
        }

        public string CodigoEscola { get; set; }
        public int AnoLetivo { get; set; }
    }
    public class ObterFuncionarioExternoEolSgaPorUeAnoLetivoQueryValidator : AbstractValidator<ObterFuncionarioExternoEolSgaPorUeAnoLetivoQuery>
    {
        public ObterFuncionarioExternoEolSgaPorUeAnoLetivoQueryValidator()
        {
            RuleFor(x => x.CodigoEscola)
                .NotEmpty()
                .WithMessage("Informe o Código da escola para realizar a consulta");

            RuleFor(x => x.AnoLetivo)
                .NotEmpty()
                .WithMessage("Informe o Ano Letivo para realizar a consulta");
        }
    }
}