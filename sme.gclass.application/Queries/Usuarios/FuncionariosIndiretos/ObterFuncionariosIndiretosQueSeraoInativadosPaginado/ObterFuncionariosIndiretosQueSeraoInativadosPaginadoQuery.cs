using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterFuncionariosIndiretosQueSeraoInativadosPaginadoQuery : IRequest<PaginacaoResultadoDto<FuncionarioIndiretoEol>>
    {
        public ObterFuncionariosIndiretosQueSeraoInativadosPaginadoQuery(Paginacao paginacao, string cpf)
        {
            Paginacao = paginacao;
            Cpf = cpf;
        }

        public Paginacao Paginacao { get; set; }
        public string Cpf { get; set; }
    }

    public class ObterFuncionariosIndiretosQueSeraoInativadosPaginadoQueryValidator : AbstractValidator<ObterFuncionariosIndiretosQueSeraoInativadosPaginadoQuery>
    {
        public ObterFuncionariosIndiretosQueSeraoInativadosPaginadoQueryValidator()
        {
            RuleFor(x => x.Paginacao)
               .NotEmpty()
               .WithMessage("A definição da paginação deve ser informada.");
        }
    }
}
