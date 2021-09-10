using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUtilmoParametroSistemaQuery : IRequest<int>
    {
    }

    public class ObterUtilmoParametroSistemaQueryValidator : AbstractValidator<ObterUtilmoParametroSistemaQuery>
    {
    }
}