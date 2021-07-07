using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterTurmasIsCadastradasQuery : IRequest<PaginacaoResultadoDto<long>>
    {
        public ObterTurmasIsCadastradasQuery(Paginacao paginacao)
        {
            Paginacao = paginacao;
        }

        public Paginacao Paginacao { get; set; }
    }

    public class ObterTurmasIsCadastradasQueryValidator : AbstractValidator<ObterTurmasIsCadastradasQuery>
    {
        public ObterTurmasIsCadastradasQueryValidator()
        {
            RuleFor(x => x.Paginacao)
                .NotNull()
                .WithMessage("A paginação deve ser informada.");
        }
    }
}
