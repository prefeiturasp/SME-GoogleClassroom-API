using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosSemGoogleClassroomIdPorTipoQuery<TEntity> : IRequest<PaginacaoResultadoDto<TEntity>>
        where TEntity : UsuarioGoogle
    {
        public Paginacao Paginacao { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }

        public ObterUsuariosSemGoogleClassroomIdPorTipoQuery(Paginacao paginacao, UsuarioTipo usuarioTipo)
        {
            Paginacao = paginacao;
            UsuarioTipo = usuarioTipo;
        }
    }

    public class ObterUsuariosSemGoogleClassroomIdPorTipoQueryValidator<TEntity> : AbstractValidator<ObterUsuariosSemGoogleClassroomIdPorTipoQuery<TEntity>>
        where TEntity : UsuarioGoogle
    {
        public ObterUsuariosSemGoogleClassroomIdPorTipoQueryValidator()
        {
            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A definição da paginação deve ser informada.");
        }
    }
}