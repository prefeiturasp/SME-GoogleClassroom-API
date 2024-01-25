using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.ExisteUsuarioPorCpfTipo
{
    public class ExisteUsuarioPorCpfTipoQuery :IRequest<bool>
    {
        public ExisteUsuarioPorCpfTipoQuery(string cpf, int tipoUsuario)
        {
            Cpf = cpf;
            TipoUsuario = tipoUsuario;
        }

        public string Cpf { get; set; }
        public int TipoUsuario { get; set; }
    }
    public class ExisteUsuarioPorCpfTipoQueryValidator : AbstractValidator<ExisteUsuarioPorCpfTipoQuery>
    {
        public ExisteUsuarioPorCpfTipoQueryValidator()
        {
            RuleFor(x => x.TipoUsuario).GreaterThan(0).WithMessage("Informe o Tipo do Usuário para realizar a consulta");
            RuleFor(x => x.Cpf).NotNull().WithMessage("Informe o CPF do Usuario para realizar a consulta");
        }
    }
}