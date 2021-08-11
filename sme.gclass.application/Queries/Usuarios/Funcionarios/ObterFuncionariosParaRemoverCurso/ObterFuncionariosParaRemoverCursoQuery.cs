using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosParaRemoverCursoQuery : IRequest<IEnumerable<RemoverAtribuicaoFuncionarioTurmaEolDto>>
    {
        public ObterFuncionariosParaRemoverCursoQuery(string turmaId, DateTime dataInicio, DateTime dataFim, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            TurmaId = turmaId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }

        public string TurmaId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }
    }

    public class ObterFuncionariosParaRemoverCursoQueryValidator : AbstractValidator<ObterFuncionariosParaRemoverCursoQuery>
    {
        public ObterFuncionariosParaRemoverCursoQueryValidator()
        {
            RuleFor(a => a.DataInicio)
                .NotEmpty()
                .WithMessage("A data de início de vigência deve ser informada para consulta de atribuições de professores a remover");

            RuleFor(a => a.DataFim)
                .NotEmpty()
                .WithMessage("A data de fim de vigência deve ser informada para consulta de atribuições de professores a remover");
            
            RuleFor(a => a.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("O parametro carga inicial deve ser informada para consulta de atribuições de professores a remover");
        }
    }
}
