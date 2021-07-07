using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirUsuarioCursoRemovidoCommand : IRequest<long>
    {
        public IncluirUsuarioCursoRemovidoCommand(long usuarioId, long cursoId, UsuarioTipo usuarioTipo)
        {
            UsuarioId = usuarioId;
            CursoId = cursoId;
            UsuarioTipo = usuarioTipo;
        }

        public long UsuarioId { get; set; }
        public long CursoId { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
    }

    public class IncluirUsuarioCursoRemovidoCommandValidator : AbstractValidator<IncluirUsuarioCursoRemovidoCommand>
    {
        public IncluirUsuarioCursoRemovidoCommandValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O id do usuario deve ser informado.");

            RuleFor(x => x.CursoId)
                .NotEmpty()
                .WithMessage("O id do curso deve ser informado.");

            RuleFor(x => x.UsuarioTipo)
                .NotEmpty()
                .WithMessage("O tipo do usuário deve ser informado.");
        }
    }
}
