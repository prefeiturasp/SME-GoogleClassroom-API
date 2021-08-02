using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosInativosPorTipoQuery: IRequest<PaginacaoResultadoDto<UsuarioInativo>>
    {
        public ObterUsuariosInativosPorTipoQuery(Paginacao paginacao, UsuarioTipo[] tiposDeUsuarios = null)
        {
            Paginacao = paginacao;
            TiposDeUsuarios = tiposDeUsuarios;
        }

        public Paginacao Paginacao { get; set; }
        public UsuarioTipo[] TiposDeUsuarios { get; set; }
    }
    public class ObterUsuariosInativosPorTipoQueryValidator : AbstractValidator<ObterUsuariosInativosPorTipoQuery>
    {
        public ObterUsuariosInativosPorTipoQueryValidator()
        {
            RuleFor(x => x.Paginacao)
                           .NotEmpty()
                           .WithMessage("A paginação deve ser informada.");

            RuleFor(x => x.Paginacao.QuantidadeRegistros)
                .GreaterThan(0)
                .WithMessage("O número da página e a quantidade de registro devem ser informados.");
        }
    }
}
