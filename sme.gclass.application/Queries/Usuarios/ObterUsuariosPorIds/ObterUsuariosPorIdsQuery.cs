using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosPorIdsQuery : IRequest<IEnumerable<UsuarioGsaDto>>
    {
        public ObterUsuariosPorIdsQuery(long[] ids)
        {
            Ids = ids;
        }

        public long[] Ids { get; set; }
    }

    public class ObterUsuariosPorIdsQueryValidator : AbstractValidator<ObterUsuariosPorIdsQuery>
    {
        public ObterUsuariosPorIdsQueryValidator()
        {
            RuleFor(x => x.Ids)
                .NotEmpty()
                .WithMessage("É necessário informar ao menos um id de usuário para realizar a consulta.");
        }
    }
}