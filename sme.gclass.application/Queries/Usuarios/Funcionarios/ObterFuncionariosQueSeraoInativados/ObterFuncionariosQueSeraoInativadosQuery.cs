using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterFuncionariosQueSeraoInativadosQuery: IRequest<PaginacaoResultadoDto<FuncionarioEol>>
    {
        public ObterFuncionariosQueSeraoInativadosQuery(Paginacao paginacao)
        {
            Paginacao = paginacao;
        }

        public Paginacao Paginacao { get; set; }
    }

    public class ObterFuncionariosQueSeraoInativadosQueryValidator : AbstractValidator<ObterFuncionariosQueSeraoInativadosQuery>
    {
        public ObterFuncionariosQueSeraoInativadosQueryValidator()
        {
            RuleFor(x => x.Paginacao)
               .NotEmpty()
               .WithMessage("A definição da paginação deve ser informada.");
        }
    }
}
