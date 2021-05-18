using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoProfessoresGsaGoogleQuery : IRequest<PaginaConsultaCursoUsuariosGsaDto>
    {
        public string CursoId { get; set; }
        public string TokenPagina { get; set; }

        public ObterCursoProfessoresGsaGoogleQuery(string cursoId, string tokenPagina)
        {
            CursoId = cursoId;
            TokenPagina = tokenPagina;
        }
    }

    public class ObterCursoProfessoresGsaGoogleQueryValidator : AbstractValidator<ObterCursoProfessoresGsaGoogleQuery>
    {
        public ObterCursoProfessoresGsaGoogleQueryValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O identificador do curso deve ser informado.");
        }
    }
}