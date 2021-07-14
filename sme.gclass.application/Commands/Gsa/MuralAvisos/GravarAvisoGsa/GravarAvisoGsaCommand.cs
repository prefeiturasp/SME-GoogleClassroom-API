using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class GravarAvisoGsaCommand : IRequest
    {
        public GravarAvisoGsaCommand(AvisoMuralGsaDto avisoDto, long usuarioIndice)
        {
            AvisoDto = avisoDto;
            UsuarioIndice = usuarioIndice;
        }

        public AvisoMuralGsaDto AvisoDto { get; }
        public long UsuarioIndice { get; }
    }

    public class GravarAvisoGsaCommandValidator : AbstractValidator<GravarAvisoGsaCommand>
    {
        public GravarAvisoGsaCommandValidator()
        {
            RuleFor(a => a.UsuarioIndice)
                .NotEmpty()
                .WithMessage("O indice do usuário deve ser informado para geração do aviso do mural");

            RuleFor(a => a.AvisoDto)
                .NotNull()
                .WithMessage("O dto de aviso do mural deve ser informado");

            When(a => !(a.AvisoDto is null), () =>
            {
                RuleFor(a => a.AvisoDto.Id)
                    .NotEmpty()
                    .WithMessage("O id do aviso deve ser informado para gravar o registro.");

                RuleFor(a => a.AvisoDto.CursoId)
                    .NotEmpty()
                    .WithMessage("O id do curso google deve ser informado para gravar o aviso do mural.");

                RuleFor(a => a.AvisoDto.UsuarioClassroomId)
                    .NotEmpty()
                    .WithMessage("O id do usuario google deve ser informado para gravar o aviso do mural.");

                RuleFor(a => a.AvisoDto.Mensagem)
                    .NotEmpty()
                    .WithMessage("A mensagem do aviso deve ser informada para gravar o aviso do mural.");
            });
        }
    }
}
