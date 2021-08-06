using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterFuncionariosIndiretosQueSeraoInativadosQuery : IRequest<IEnumerable<string>>
    {
        public ObterFuncionariosIndiretosQueSeraoInativadosQuery(string cpf)
        {
            Cpf = cpf;
        }

        public string Cpf { get; set; }
    }

    public class ObterFuncionariosIndiretosQueSeraoInativadosQueryValidator : AbstractValidator<ObterFuncionariosIndiretosQueSeraoInativadosQuery>
    {
    }
}
