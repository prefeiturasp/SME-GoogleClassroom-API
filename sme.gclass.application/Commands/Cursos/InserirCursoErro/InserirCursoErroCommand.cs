using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoErroCommand : IRequest<long>
    {
        public InserirCursoErroCommand(long turmaId, long componenteCurricularId, string mensagem, long? cursoId, ExecucaoTipo execucaoTipo, ErroTipo erroTipo)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            Mensagem = mensagem;
            CursoId = cursoId;
            ExecucaoTipo = execucaoTipo;
            ErroTipo = erroTipo;
        }

        public long TurmaId { get; set; }

        public long ComponenteCurricularId { get; set; }

        public string Mensagem { get; set; }

        public long? CursoId { get; set; }

        public ExecucaoTipo ExecucaoTipo { get; set; }
        public ErroTipo ErroTipo { get; set; }
    }

    public class InserirCursoErroCommandValidator : AbstractValidator<InserirCursoErroCommand>
    {
        public InserirCursoErroCommandValidator()
        {

            RuleFor(c => c.Mensagem)
                   .NotEmpty()
                   .WithMessage("A mensagem deve ser informada.");

            RuleFor(c => c.ExecucaoTipo)
               .NotEmpty()
               .WithMessage("O tipo da execução deve ser informada.");

            RuleFor(c => c.ErroTipo)
               .NotEmpty()
               .WithMessage("O tipo da erro deve ser informado.");
        }
    }
}
