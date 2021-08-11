using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAtribuicoesDeCursosDosProfessoresQuery : IRequest<PaginacaoResultadoDto<AtribuicaoProfessorCursoEol>>
    {
        public DateTime UltimaDataExecucao { get; set; }
        public Paginacao Paginacao { get; set; }
        public string Rf { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
        public ParametrosCargaInicialDto parametrosCargaInicialDto;

        public ObterAtribuicoesDeCursosDosProfessoresQuery(DateTime ultimaDataExecucao, Paginacao paginacao, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            UltimaDataExecucao = ultimaDataExecucao;
            Paginacao = paginacao;
            this.parametrosCargaInicialDto = parametrosCargaInicialDto;
        }

        public ObterAtribuicoesDeCursosDosProfessoresQuery(DateTime ultimaDataExecucao, Paginacao paginacao, string rf, long? turmaId, long? componenteCurricularId, ParametrosCargaInicialDto parametrosCargaInicialDto)
            :this(ultimaDataExecucao, paginacao, parametrosCargaInicialDto)
        {
            Rf = rf;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }
    }

    public class ObterAtribuicoesDeCursosDoProfessorQueryValidator : AbstractValidator<ObterAtribuicoesDeCursosDosProfessoresQuery>
    {
        public ObterAtribuicoesDeCursosDoProfessorQueryValidator()
        {
            RuleFor(x => x.UltimaDataExecucao)
                .NotEmpty()
                .WithMessage("A última data de execução deve ser informada.");

            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A página e a quantidade de registros devem ser informados.");

            RuleFor(x => x.TurmaId)
                .NotEmpty()
                .When(x => !(x.TurmaId is null))
                .WithMessage("A turma informada é inválida.");

            RuleFor(x => x.ComponenteCurricularId)
                .NotEmpty()
                .When(x => !(x.ComponenteCurricularId is null))
                .WithMessage("O componente curricular informado é inválido.");
            
            RuleFor(x => x.ComponenteCurricularId)
                .NotNull()
                .When(x => !(x.parametrosCargaInicialDto is null))
                .WithMessage("O parametros de carga inicial informado é inválido.");
        }
    }
}