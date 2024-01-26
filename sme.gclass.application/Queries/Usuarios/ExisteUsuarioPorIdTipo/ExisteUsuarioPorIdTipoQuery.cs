using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.ExisteUsuarioPorIdTipo
{
    public class ExisteUsuarioPorIdTipoQuery : IRequest<bool>
    {
        public ExisteUsuarioPorIdTipoQuery(long id, int tipoUsuario)
        {
            Id = id;
            TipoUsuario = tipoUsuario;
        }

        public long Id { get; set; }
        public int TipoUsuario { get; set; }
    }

    public class ExisteUsuarioPorIdTipoQueryValidator : AbstractValidator<ExisteUsuarioPorIdTipoQuery>
    {
        public ExisteUsuarioPorIdTipoQueryValidator()
        {
            RuleFor(x => x.TipoUsuario).GreaterThan(0).WithMessage("Informe o Tipo do Usuário para realizar a consulta");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Informe o Id do Usuario para realizar a consulta");
        }
    }
}