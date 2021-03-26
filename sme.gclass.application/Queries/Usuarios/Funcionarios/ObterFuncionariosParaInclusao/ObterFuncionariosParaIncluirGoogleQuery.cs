using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosParaIncluirGoogleQuery : IRequest<PaginacaoResultadoDto<FuncionarioEol>>
    {
        public ObterFuncionariosParaIncluirGoogleQuery(DateTime ultimaDataExecucao, Paginacao paginacao, string rf)
        {
            UltimaDataExecucao = ultimaDataExecucao;
            Paginacao = paginacao;
            Rf = rf;
        }

        public DateTime UltimaDataExecucao { get; set; }
        public Paginacao Paginacao { get; set; }
        public string Rf { get; set; }
    }

    public class ObterFuncionariosParaInclusaoQueryValidator : AbstractValidator<ObterFuncionariosParaIncluirGoogleQuery>
    {
        public ObterFuncionariosParaInclusaoQueryValidator()
        {
            RuleFor(x => x.UltimaDataExecucao)
                .NotEmpty()
                .WithMessage("A última data de execução deve ser informada.");

            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A página e a quantidade de registros devem ser informados.");
        }
    }
}