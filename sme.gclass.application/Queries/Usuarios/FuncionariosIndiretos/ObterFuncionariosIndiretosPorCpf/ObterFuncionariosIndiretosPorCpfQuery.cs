using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosIndiretosPorCpfQuery : IRequest<IEnumerable<FuncionarioIndiretoGoogle>>
    {
        public string[] Cpfs { get; set; }

        public ObterFuncionariosIndiretosPorCpfQuery(string[] cpfs)
        {
            Cpfs = cpfs;
        }
    }

    public class ObterFuncionariosIndiretosPorCpfQueryValidator : AbstractValidator<ObterFuncionariosIndiretosPorCpfQuery>
    {
    }
}