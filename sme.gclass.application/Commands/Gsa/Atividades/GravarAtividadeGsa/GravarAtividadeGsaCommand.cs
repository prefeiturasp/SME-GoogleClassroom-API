using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class GravarAtividadeGsaCommand : IRequest
    {
        public GravarAtividadeGsaCommand(AtividadeGsaDto atividadeDto)
        {
            AtividadeDto = atividadeDto;
        }

        public AtividadeGsaDto AtividadeDto { get; }
    }

    public class GravarAtividadeGsaCommandValidator : AbstractValidator<GravarAtividadeGsaCommand>
    {
        public GravarAtividadeGsaCommandValidator()
        {
            RuleFor(a => a.AtividadeDto)
                .NotNull()
                .WithMessage("O dto de atividade avaliativa deve ser informado");

            When(a => !(a.AtividadeDto is null), () =>
            {
                RuleFor(a => a.AtividadeDto.Id)
                    .NotEmpty()
                    .WithMessage("O id da atividade avaliativa deve ser informado para gravar o registro.");

                RuleFor(a => a.AtividadeDto.CursoId)
                    .NotEmpty()
                    .WithMessage("O id do curso google deve ser informado para gravar a atividade avaliativa.");

                RuleFor(a => a.AtividadeDto.UsuarioClassroomId)
                    .NotEmpty()
                    .WithMessage("O id do usuario google deve ser informado para gravar a atividade avaliativa.");

                RuleFor(a => a.AtividadeDto.Titulo)
                    .NotEmpty()
                    .WithMessage("O título da atividade deve ser informada para gravar a atividade avaliativa.");

                RuleFor(a => a.AtividadeDto.Descricao)
                    .NotEmpty()
                    .WithMessage("A descrição da atividade deve ser informada para gravar a atividade avaliativa.");
            });
        }
    }
}
