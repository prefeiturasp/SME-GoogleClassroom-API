using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirParametroCargaInicialCommand : IRequest<bool>
    {
        public int Ano { get; set; }
        public IList<int> TiposUes { get; set; }
        public IList<long> Ues { get; set; }
        public IList<long> Turmas { get; set; }

        public IncluirParametroCargaInicialCommand(FiltroCargaInicialDto filtro)
        {
            Ano = filtro.AnoLetivo;
            TiposUes = filtro.TiposUes;
            Ues = filtro.Ues;
            Turmas = filtro.Turmas;
        }

        public class
            IncluirParametroCargaInicialCommandValidator : AbstractValidator<IncluirParametroCargaInicialCommand>
        {
            public IncluirParametroCargaInicialCommandValidator()
            {
                RuleFor(x => x.Ano)
                    .NotEmpty()
                    .WithMessage("O Ano é obrigatório");
            }
        }
    }
}
