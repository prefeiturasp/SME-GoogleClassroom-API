using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterGradesAtuaisDeCursosQuery : IRequest<PaginacaoResultadoDto<CursoGoogle>>
    {
        public Paginacao Paginacao { get; set; }
        public DateTime UltimaDataExecucao { get; set; }

        public ObterGradesAtuaisDeCursosQuery(DateTime ultimaDataExecucao, Paginacao paginacao)
        {
            UltimaDataExecucao = ultimaDataExecucao;
            Paginacao = paginacao;
        }
    }

    public class ObterGradesAtuaisDeCursosQueryValidator : AbstractValidator<ObterGradesAtuaisDeCursosQuery>
    {
        public ObterGradesAtuaisDeCursosQueryValidator()
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
