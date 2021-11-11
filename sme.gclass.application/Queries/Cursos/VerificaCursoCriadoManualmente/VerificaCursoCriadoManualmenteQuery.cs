using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class VerificaCursoCriadoManualmenteQuery : IRequest<bool>
    {
        public VerificaCursoCriadoManualmenteQuery(long cursoId)
        {
            CursoId = cursoId;
        }
        public long CursoId { get; set; }  
    }
    public class VerificaCursoCriadoManualmenteQueryValidator : AbstractValidator<VerificaCursoCriadoManualmenteQuery>
    {
        public VerificaCursoCriadoManualmenteQueryValidator()
        {
            RuleFor(c => c.CursoId)
                .NotEmpty()
                .WithMessage("O id do curso é necessário para verificar se o curso foi criado manualmente na base");
        }
    }
}
