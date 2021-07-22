using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterProfessoresParaRemoverCursoPaginadoQuery : IRequest<PaginacaoResultadoDto<RemoverAtribuicaoProfessorCursoEolDto>>
    {
        public ObterProfessoresParaRemoverCursoPaginadoQuery(string turmaId, DateTime dataInicio, DateTime dataFim, Paginacao paginacao)
        {
            TurmaId = turmaId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Paginacao = paginacao;
        }

        public string TurmaId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public Paginacao Paginacao { get; private set; }
    }

    public class ObterProfessoresParaRemoverCursoPaginadoQueryValidator : AbstractValidator<ObterProfessoresParaRemoverCursoPaginadoQuery>
    {
        public ObterProfessoresParaRemoverCursoPaginadoQueryValidator()
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
