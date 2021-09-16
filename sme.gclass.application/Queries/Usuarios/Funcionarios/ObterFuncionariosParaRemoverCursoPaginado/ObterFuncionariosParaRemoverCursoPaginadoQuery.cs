using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosParaRemoverCursoPaginadoQuery : IRequest<PaginacaoResultadoDto<RemoverAtribuicaoFuncionarioTurmaEolDto>>
    {
        public ObterFuncionariosParaRemoverCursoPaginadoQuery(string turmaId, DateTime dataInicio, DateTime dataFim, Paginacao paginacao, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            TurmaId = turmaId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Paginacao = paginacao;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }

        public string TurmaId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public Paginacao Paginacao { get; private set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; private set; }
    }

    public class ObterFuncionariosParaRemoverCursoPaginadoQueryValidator : AbstractValidator<ObterFuncionariosParaRemoverCursoPaginadoQuery>
    {
        public ObterFuncionariosParaRemoverCursoPaginadoQueryValidator()
        {
            RuleFor(a => a.DataInicio)
                .NotEmpty()
                .WithMessage("A data de início de vigência deve ser informada para consulta de atribuições de professores a remover");

            RuleFor(a => a.DataFim)
                .NotEmpty()
                .WithMessage("A data de fim de vigência deve ser informada para consulta de atribuições de professores a remover");
        }
    }
}
