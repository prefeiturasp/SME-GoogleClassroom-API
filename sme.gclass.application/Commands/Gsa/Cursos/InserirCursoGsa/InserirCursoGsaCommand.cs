using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoGsaCommand : IRequest<bool>
    {
        public InserirCursoGsaCommand(CursoGsa cursoGsa)
        {
            CursoGsa = cursoGsa;
        }

        public CursoGsa CursoGsa { get; set; }
    }

    public class InserirComparativoCursoCommandValidator : AbstractValidator<InserirCursoGsaCommand>
    {
        public InserirComparativoCursoCommandValidator()
        {
            RuleFor(x => x.CursoGsa)
                .NotEmpty()
                .WithMessage("");

            When(x => !(x.CursoGsa is null), () =>
            {
                RuleFor(x => x.CursoGsa.Id)
                    .NotEmpty()
                    .WithMessage("O ID do curso deve ser informado.");

                RuleFor(x => x.CursoGsa.Nome)
                    .NotEmpty()
                    .WithMessage("O nome do curso deve ser informado.");

                RuleFor(x => x.CursoGsa.Secao)
                    .NotEmpty()
                    .WithMessage("O nome da seção do curso deve ser informado.");

                RuleFor(x => x.CursoGsa.CriadorId)
                    .NotEmpty()
                    .WithMessage("O ID do criador do curso deve ser informado.");

                RuleFor(x => x.CursoGsa.DataInclusao)
                    .NotEmpty()
                    .WithMessage("A data de inclusão do curso deve ser informado.");
            });
        }
    }
}