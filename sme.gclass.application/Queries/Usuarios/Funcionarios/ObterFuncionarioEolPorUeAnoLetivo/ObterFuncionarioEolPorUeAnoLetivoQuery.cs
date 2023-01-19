using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Funcionarios.ObterFuncionarioEolPorUeAnoLetivo
{
    public class ObterFuncionarioEolPorUeAnoLetivoQuery : IRequest<IEnumerable<FuncionarioSgaDto>>
    {
        public ObterFuncionarioEolPorUeAnoLetivoQuery(string codigoEscola, int anoLetivo,bool escolaEhCieja = false)
        {
            CodigoEscola = codigoEscola;
            AnoLetivo = anoLetivo;
            EscolaEhCieja = escolaEhCieja;
        }

        public string CodigoEscola { get; set; }
        public int AnoLetivo { get; set; }
        public bool EscolaEhCieja { get; set; }
    }
    
    public class ObterFuncionarioEolPorUeAnoLetivoQueryValidator : AbstractValidator<ObterFuncionarioEolPorUeAnoLetivoQuery>
    {
        public ObterFuncionarioEolPorUeAnoLetivoQueryValidator()
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