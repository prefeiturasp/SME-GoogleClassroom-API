using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Usuarios
{
    public class AtualizarInserirEmailUsuarioCommand : IRequest<bool>
    {
        public AtualizarInserirEmailUsuarioCommand(UsuarioEmailDto usuario)
        {
            Usuario = usuario;
        }

        public UsuarioEmailDto Usuario { get; set; }
    }

    public class IAtualizarInserirEmailUsuarioUseCaseValiador : AbstractValidator<AtualizarInserirEmailUsuarioCommand>
    {
        public IAtualizarInserirEmailUsuarioUseCaseValiador()
        {
            RuleFor(x => x.Usuario).NotNull().WithMessage("Informe o usuario para atualizar ou inserir");
        }
    }
}