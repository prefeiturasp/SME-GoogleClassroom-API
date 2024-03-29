﻿using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCadastradosQuery : IRequest<PaginacaoResultadoDto<AlunoGoogle>>
    {
        public ObterAlunosCadastradosQuery(Paginacao paginacao, long? codigoEol, string email)
        {
            Paginacao = paginacao;
            CodigoEol = codigoEol;
            Email = email;
        }

        public Paginacao Paginacao { get; set; }
        public long? CodigoEol { get; set; }
        public string Email { get; set; }
    }

    public class ObterAlunosCadastradosQueryValidator : AbstractValidator<ObterAlunosCadastradosQuery>
    {
        public ObterAlunosCadastradosQueryValidator()
        {
            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A paginação deve ser informada.");

            RuleFor(x => x.Paginacao.QuantidadeRegistros)
                .GreaterThan(0)
                .WithMessage("O número da página e a quantidade de registro devem ser informados.");
        }
    }
}
