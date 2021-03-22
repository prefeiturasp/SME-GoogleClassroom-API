using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirCursoUsuarioErroCommand : IRequest<long>
    {
        public long? Rf { get; set; }
        public string Email { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
        public ErroTipo ErroTipo { get; set; }
        public ExecucaoTipo ExecucaoTipo { get; set; }
        public string Mensagem { get; set; }
        public IncluirCursoUsuarioErroCommand(long? rf, long turmaId, long componenteCurricularId, ExecucaoTipo execucaoTipo, ErroTipo erroTipo, string mensagem)
        {
            Rf = rf;            
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            ExecucaoTipo = execucaoTipo;
            ErroTipo = erroTipo;
            Mensagem = mensagem;
        }

        public IncluirCursoUsuarioErroCommand(long? rf, ExecucaoTipo execucaoTipo, ErroTipo erroTipo, string mensagem)
        {
            Rf = rf;
            ExecucaoTipo = execucaoTipo;
            ErroTipo = erroTipo;
            Mensagem = mensagem;
        }

        public IncluirCursoUsuarioErroCommand(long turmaId, long componenteCurricularId, ExecucaoTipo execucaoTipo, ErroTipo erroTipo, string mensagem)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            ExecucaoTipo = execucaoTipo;
            ErroTipo = erroTipo;
            Mensagem = mensagem;
        }
    }

    public class IncluirCursoUsuarioErroCommandValidator : AbstractValidator<IncluirCursoUsuarioErroCommand>
    {
        public IncluirCursoUsuarioErroCommandValidator()
        {
            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .When(x => !(x.TurmaId is null))
                .WithMessage("A turma do professor deve ser informado para inserir um regitro na tabela de erro.");

            RuleFor(x => x.ComponenteCurricularId)
                .NotEmpty()
                .When(x => !(x.ComponenteCurricularId is null))
                .WithMessage("O componente curricular do professor deve ser informado para inserir um regitro na tabela de erro.");

            RuleFor(x => x.Mensagem)
                .NotEmpty()
                .WithMessage("A mensagem do professor deve ser informado para inserir um regitro na tabela de erro.");
        }
    }
}