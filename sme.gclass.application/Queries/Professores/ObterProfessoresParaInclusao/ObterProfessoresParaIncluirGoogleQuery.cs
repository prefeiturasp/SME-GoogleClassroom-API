using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresParaIncluirGoogleQuery : IRequest<PaginacaoResultadoDto<ProfessorParaIncluirGoogleDto>>
    {
        public ObterProfessoresParaIncluirGoogleQuery(DateTime ultimaDataExecucao, Paginacao paginacao)
        {
            UltimaDataExecucao = ultimaDataExecucao;
            Paginacao = paginacao;
        }

        public DateTime UltimaDataExecucao { get; set; }
        public Paginacao Paginacao { get; set; }
    }

    public class ObterProfessoresParaIncluirGoogleQueryValidator : AbstractValidator<ObterProfessoresParaIncluirGoogleQuery>
    {
        public ObterProfessoresParaIncluirGoogleQueryValidator()
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
