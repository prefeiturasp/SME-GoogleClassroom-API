using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao.Usuarios
{
    public class ObterFuncionarioCursoPorUsuarioRfCursoIdQuery : IRequest<FuncionarioCurso>
    {
        public long UsuarioRf { get; set; }
        public long CursoId { get; set; }

        public ObterFuncionarioCursoPorUsuarioRfCursoIdQuery(long usuarioRf, long cursoId)
        {
            UsuarioRf = usuarioRf;
            CursoId = cursoId;
        }

        public ObterFuncionarioCursoPorUsuarioRfCursoIdQuery()
        {
        }
        
        
        
        public class ObterFuncionarioCursoPorUsuarioRfCursoIdQueryValidator : AbstractValidator<ObterFuncionarioCursoPorUsuarioRfCursoIdQuery>
        {
            public ObterFuncionarioCursoPorUsuarioRfCursoIdQueryValidator()
            {
                RuleFor(x => x.UsuarioRf)
                    .NotEmpty()
                    .WithMessage("O Usuario RF deve ser informado para consulta do usuário no Google Classroom.");
                
                RuleFor(x => x.CursoId)
                    .NotEmpty()
                    .WithMessage("O Curso Id deve ser informado para consulta do curso no Google Classroom.");
            }
        }
    }
}