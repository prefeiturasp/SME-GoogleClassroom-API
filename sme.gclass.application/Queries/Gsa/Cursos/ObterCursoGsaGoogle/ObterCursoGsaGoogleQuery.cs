using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoGsaGoogleQuery : IRequest<CursoGsaDto>
    {
        public string CursoId { get; set; }

        public ObterCursoGsaGoogleQuery(string cursoId)
        {
            CursoId = cursoId;
        }
    }

    public class ObterCursoGsaGoogleQueryValidator : AbstractValidator<ObterCursoGsaGoogleQuery>
    {
        public ObterCursoGsaGoogleQueryValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O identifcador do curso GSA deve ser informado.");
        }
    }
}