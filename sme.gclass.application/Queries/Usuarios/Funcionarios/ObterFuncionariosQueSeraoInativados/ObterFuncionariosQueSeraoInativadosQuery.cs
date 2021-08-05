using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class ObterFuncionariosQueSeraoInativadosQuery: IRequest<PaginacaoResultadoDto<FuncionarioEol>>
    {
        public ObterFuncionariosQueSeraoInativadosQuery(Paginacao paginacao, DateTime dataReferencia, string codigoRf)
        {
            Paginacao = paginacao;
            DataReferencia = dataReferencia;
            CodigoRf = codigoRf;
        }

        public Paginacao Paginacao { get; set; }
        public DateTime DataReferencia { get; set; }
        public string CodigoRf { get; set; }
    }

    public class ObterFuncionariosQueSeraoInativadosQueryValidator : AbstractValidator<ObterFuncionariosQueSeraoInativadosQuery>
    {
        public ObterFuncionariosQueSeraoInativadosQueryValidator()
        {
            RuleFor(x => x.Paginacao)
               .NotEmpty()
               .WithMessage("A definição da paginação deve ser informada.");
            
            RuleFor(x => x.DataReferencia)
               .NotEmpty()
               .WithMessage("A data de referência deve ser informada.");
        }
    }
}
