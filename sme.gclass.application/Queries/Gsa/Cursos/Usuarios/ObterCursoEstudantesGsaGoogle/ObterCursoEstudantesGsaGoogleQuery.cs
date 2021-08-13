using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursoEstudantesGsaGoogleQuery : IRequest<PaginaConsultaCursoUsuariosGsaDto>
    {
        public long CursoId { get; set; }
        public string TokenPagina { get; set; }

        public ObterCursoEstudantesGsaGoogleQuery(long cursoId, string tokenPagina)
        {
            CursoId = cursoId;
            TokenPagina = tokenPagina;
        }
    }

    public class ObterUsuarioCursosGsaGoogleQueryValidator : AbstractValidator<ObterCursoEstudantesGsaGoogleQuery>
    {
        public ObterUsuarioCursosGsaGoogleQueryValidator()
        {
            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O identificador do curso deve ser informado.");
        }
    }
}