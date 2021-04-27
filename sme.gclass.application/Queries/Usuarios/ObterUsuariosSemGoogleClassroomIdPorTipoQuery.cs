using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosSemGoogleClassroomIdPorTipoQuery : IRequest<PaginacaoResultadoDto<UsuarioParaAtualizacaoGoogleClassroomIdDto>>
    {
        public Paginacao Paginacao { get; set; }

        public ObterUsuariosSemGoogleClassroomIdPorTipoQuery(Paginacao paginacao)
        {
            Paginacao = paginacao;
        }
    }

    public class ObterUsuariosSemGoogleClassroomIdPorTipoQueryValidator : AbstractValidator<ObterUsuariosSemGoogleClassroomIdPorTipoQuery>
    {
        public ObterUsuariosSemGoogleClassroomIdPorTipoQueryValidator()
        {
            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A definição da paginação deve ser informada.");
        }
    }
}