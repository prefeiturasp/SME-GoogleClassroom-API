using MediatR;
using System.Collections.Generic;
using FluentValidation;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class LancarFrequenciaCommand : IRequest<bool>
    {
        public LancarFrequenciaCommand(FrequenciaSalvarAulaAlunosDto frequenciaSalvarAulaAlunosDto)
        {
            FrequenciaSalvarAulaAlunos = frequenciaSalvarAulaAlunosDto;
        }

        public FrequenciaSalvarAulaAlunosDto FrequenciaSalvarAulaAlunos { get; set; }
    }
    
    public class LancarFrequenciaCommandValidator : AbstractValidator<LancarFrequenciaCommand>
    {
        public LancarFrequenciaCommandValidator()
        {
            RuleFor(c => c.FrequenciaSalvarAulaAlunos)
                .NotNull()
                .WithMessage("A frequência deve ser informada para o lançamento da frequência.");
        }
    }
}
