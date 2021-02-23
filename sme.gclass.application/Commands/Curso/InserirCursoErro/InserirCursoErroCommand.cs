using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoErroCommand : IRequest<long>
    {
        public InserirCursoErroCommand(int turmaId, int componenteCurricularId, string mensagem, long? cursoId, ExecucaoTipo execucaoTipo)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            Mensagem = mensagem;
            CursoId = cursoId;
            ExecucaoTipo = execucaoTipo;
        }

        public int TurmaId { get; set; }

        public int ComponenteCurricularId { get; set; }

        public string Mensagem { get; set; }

        public long? CursoId { get; set; }

        public ExecucaoTipo ExecucaoTipo { get; set; }
    }

    public class InserirCursoErroCommandValidator : AbstractValidator<InserirCursoErroCommand>
    {
        public InserirCursoErroCommandValidator()
        {

            RuleFor(c => c.TurmaId)
                .NotEmpty()
                .WithMessage("O Id da Turma deve ser informado.");

            RuleFor(c => c.ComponenteCurricularId)
                .NotEmpty()
                .WithMessage("O Componente Curricular deve ser informado.");

            RuleFor(c => c.Mensagem)
                .NotEmpty()
                .WithMessage("A mensagem deve ser informada.");

            RuleFor(c => c.ExecucaoTipo)
               .NotEmpty()
               .WithMessage("O tipo da execução deve ser informada.");
        }
    }
}
