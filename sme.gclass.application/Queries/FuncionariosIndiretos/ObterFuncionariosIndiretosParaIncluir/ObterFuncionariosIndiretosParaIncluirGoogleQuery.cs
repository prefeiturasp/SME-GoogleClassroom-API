using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosIndiretosParaIncluirGoogleQuery : IRequest<PaginacaoResultadoDto<FuncionarioIndiretoEol>>
    {
        public ObterFuncionariosIndiretosParaIncluirGoogleQuery(DateTime ultimaDataExecucao, Paginacao paginacao)
        {
            UltimaDataExecucao = ultimaDataExecucao;
            Paginacao = paginacao;
        }

        public ObterFuncionariosIndiretosParaIncluirGoogleQuery(DateTime ultimaDataExecucao, Paginacao paginacao, string cpf)
            :this(ultimaDataExecucao, paginacao)
        {
            Cpf = cpf;
        }

        public DateTime UltimaDataExecucao { get; set; }
        public Paginacao Paginacao { get; set; }
        public string Cpf { get; set; }
    }

    public class ObterFuncionariosIndiretosParaIncluirGoogleQueryValidator : AbstractValidator<ObterFuncionariosIndiretosParaIncluirGoogleQuery>
    {
        public ObterFuncionariosIndiretosParaIncluirGoogleQueryValidator()
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