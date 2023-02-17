using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra.Dtos.Gsa;

namespace SME.GoogleClassroom.Aplicacao.Queries.Sga.ObterPerfilUsuario
{
    public class ObterPerfilFuncionarioQuery : IRequest<IEnumerable<PerfilFuncionarioDto>>
    {
        public ObterPerfilFuncionarioQuery(int[] codigosFuncao , bool ehFuncionarioExterno)
        {
            CodigosFuncao = codigosFuncao;
            EhFuncionarioExterno = ehFuncionarioExterno;
        }

        public int[] CodigosFuncao { get; set; }
        public bool EhFuncionarioExterno { get; set; }
    }
    public class ObterPerfilFuncionarioQueryValidator : AbstractValidator<ObterPerfilFuncionarioQuery>
    {
        public ObterPerfilFuncionarioQueryValidator()
        {
            RuleFor(x => x.CodigosFuncao)
                .NotEmpty()
                .WithMessage("Informe o Código da função para realizar a consulta");
        }
    }
}