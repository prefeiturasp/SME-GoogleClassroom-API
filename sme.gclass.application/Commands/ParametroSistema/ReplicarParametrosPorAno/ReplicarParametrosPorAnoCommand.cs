using System.Collections.Generic;
using FluentValidation;
using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ReplicarParametrosPorAnoCommand : IRequest<bool>
    {
        public int Ano { get; set; }

        public ReplicarParametrosPorAnoCommand(int ano)
        {
            Ano = ano;
        }

        public class ReplicarParametrosPorAnoCommandValidation : AbstractValidator<ReplicarParametrosPorAnoCommand>
        {
            public ReplicarParametrosPorAnoCommandValidation()
            {

                RuleFor(x => x.Ano)
                    .NotEmpty()
                    .WithMessage("O Ano deve ser informado.");

            }
        }

    }
}