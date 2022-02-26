using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresPorDreComponenteCurricularModalidadeQuery : IRequest<IEnumerable<string>>
    {
        public string ComponentesCurricularIds { get; set; }
        public string ModalidadesIds { get; set; }
        public int[] TipoEscola { get; set; }
        public int AnoLetivo { get; set; }
        public string AnoTurma { get; set; }
        public string[] CodigosDre { get; set; }

        public ObterProfessoresPorDreComponenteCurricularModalidadeQuery(string componentesCurricularIds, string modalidadesIds, int[] tipoEscola, int anoLetivo, string anoTurma, string[] codigosDre)
        {
            ComponentesCurricularIds = componentesCurricularIds;
            ModalidadesIds = modalidadesIds;
            TipoEscola = tipoEscola;
            AnoLetivo = anoLetivo;
            AnoTurma = anoTurma;
            CodigosDre = codigosDre;
        }
    }

    public class ObterProfessoresPorDreComponenteCurricularModalidadeQueryValidator : AbstractValidator<ObterProfessoresPorDreComponenteCurricularModalidadeQuery>
    {
        public ObterProfessoresPorDreComponenteCurricularModalidadeQueryValidator()
        {           
            RuleFor(x => x.ComponentesCurricularIds)
                .NotEmpty()
                .WithMessage("Componentes curriculares devem ser informados.");

            RuleFor(x => x.ModalidadesIds)
                .NotEmpty()
                .WithMessage("Modalidades devem ser informados.");

            RuleFor(x => x.TipoEscola)
                .NotEmpty()
                .WithMessage("Tipo escola deve ser informado.");

            RuleFor(x => x.AnoLetivo)
               .NotEmpty()
               .WithMessage("Ano letivo deve ser informado.");
        }
    }
}