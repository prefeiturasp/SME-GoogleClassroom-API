using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra.Dtos.Sga;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao.Queries.Sga.ObterProfessorCjSgp
{
    public class ObterProfessorCjSgpQuery : IRequest<IEnumerable<ProfessorCjSgpDto>>
    {
        public ObterProfessorCjSgpQuery(int anoLetivo, string codigoEscola)
        {
            AnoLetivo = anoLetivo;
            CodigoEscola = codigoEscola;
        }

        public int AnoLetivo { get; set; }
        public string CodigoEscola { get; set; }
    }

    public class ObterProfessorCjSgpQueryValidator : AbstractValidator<ObterProfessorCjSgpQuery>
    {
        public ObterProfessorCjSgpQueryValidator()
        {
            RuleFor(x => x.AnoLetivo)
                    .GreaterThan(0)
                    .WithMessage("O Ano Letivo é obrigatório");

            RuleFor(x => x.AnoLetivo)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Código da Escola é obrigatório");
        }
    }
}
