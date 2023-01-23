using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra.Dtos.Sga;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao.Queries.Sga.ObterDadosProfessoresPorRfs
{
    public class ObterDadosProfessoresPorRfsQuery : IRequest<IEnumerable<DadosProfessorEolSgaDto>>
    {
        public string[] Rfs { get; set; }

        public ObterDadosProfessoresPorRfsQuery(string[] rfs)
        {
            Rfs = rfs;
        }
    }

    public class ObterDadosProfessoresPorRfsQueryValidator : AbstractValidator<ObterDadosProfessoresPorRfsQuery>
    {
        public ObterDadosProfessoresPorRfsQueryValidator()
        {
            RuleFor(x => x.Rfs)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Código da Escola é obrigatório");
        }
    }
}
