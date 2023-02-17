using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Funcionarios.ObterFuncionarioExternoEolSgaPorUeAnoLetivo
{
    public class ObterFuncionarioExternoEolPorUeAnoLetivoQuery  : IRequest<IEnumerable<FuncionarioDto>>
    {
        public ObterFuncionarioExternoEolPorUeAnoLetivoQuery(string codigoEscola, int anoLetivo)
        {
            CodigoEscola = codigoEscola;
            AnoLetivo = anoLetivo;
        }

        public string CodigoEscola { get; set; }
        public int AnoLetivo { get; set; }
    }
    public class ObterFuncionarioExternoEolSgaPorUeAnoLetivoQueryValidator : AbstractValidator<ObterFuncionarioExternoEolPorUeAnoLetivoQuery>
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