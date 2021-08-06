using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosInativosPorTipoQuery: IRequest<PaginacaoResultadoDto<UsuarioInativoDto>>
    {
        public Paginacao Paginacao { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }

        public ObterUsuariosInativosPorTipoQuery(Paginacao paginacao, UsuarioTipo usuarioTipo)
        {
            Paginacao = paginacao;
            UsuarioTipo = usuarioTipo;
        }
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