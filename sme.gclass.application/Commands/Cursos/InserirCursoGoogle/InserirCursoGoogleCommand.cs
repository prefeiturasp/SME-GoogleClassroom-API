using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoGoogleCommand : IRequest<bool>
    {
        public InserirCursoGoogleCommand(CursoGoogle cursoGoogle)
        {
            CursoGoogle = cursoGoogle;
        }

        public CursoGoogle CursoGoogle { get; set; }
    }

    public class InserirCursoGoogleCommandValidator : AbstractValidator<InserirCursoGoogleCommand>
    {
        public InserirCursoGoogleCommandValidator()
        {
            RuleFor(x => x.CursoGoogle)
                .NotEmpty()
                .WithMessage("É necessário informar o curso que será incluído no Google Classroom.");
        }
    }
}