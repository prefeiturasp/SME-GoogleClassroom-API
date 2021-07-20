using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarImportacaoAvisosCommand : IRequest
    {
        public TratarImportacaoAvisosCommand(ICollection<AvisoMuralGsaDto> avisos, long cursoId)
        {
            Avisos = avisos;
            CursoId = cursoId;
        }

        public ICollection<AvisoMuralGsaDto> Avisos { get; set; }
        public long CursoId { get; set; }
    }

    public class TratarImportacaoAvisosCommandValidator : AbstractValidator<TratarImportacaoAvisosCommand>
    {
        public TratarImportacaoAvisosCommandValidator()
        {
            RuleFor(a => a.Avisos)
                .NotEmpty()
                .WithMessage("Os avisos devem ser informados para tratamento da importação dos avisos do mural");

            RuleFor(a => a.CursoId)
                .NotEmpty()
                .WithMessage("O id do curso deve ser informado para tratamento da importação dos avisos do mural");
        }
    }
}
