using System.Collections.Generic;
using FluentValidation;
using Google.Apis.Admin.Directory.directory_v1.Data;
using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ReplicarParametrosDoSistemaPorAnoCommand : IRequest<bool>
    {
        public int Ano { get; set; }

        public ReplicarParametrosDoSistemaPorAnoCommand(int ano)
        {
            Ano = ano;
        }

        public class ReplicarParametrosPorAnoCommandValidation : AbstractValidator<ReplicarParametrosDoSistemaPorAnoCommand>
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