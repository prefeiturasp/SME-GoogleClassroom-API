using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao.Queries.UE.ObterTipoDaUe
{
    public class ObterTipoDaEscolaQuery :IRequest<int>
    {
        public ObterTipoDaEscolaQuery(string codigoEscola)
        {
            CodigoEscola = codigoEscola;
        }

        public string CodigoEscola { get; set; }  
    }
    
    public class ObterTipoDaEscolaQueryValidator : AbstractValidator<ObterTipoDaEscolaQuery>
    {
        public ObterTipoDaEscolaQueryValidator()
        {
            RuleFor(x => x.CodigoEscola)
                .NotEmpty()
                .WithMessage("Informe o Codido da Escola para realizar a consulta");
        }
    }
}