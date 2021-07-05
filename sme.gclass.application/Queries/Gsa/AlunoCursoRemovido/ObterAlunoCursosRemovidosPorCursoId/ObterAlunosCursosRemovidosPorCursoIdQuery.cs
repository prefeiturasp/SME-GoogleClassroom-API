using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAlunosCursosRemovidosPorCursoIdQuery : IRequest<PaginacaoResultadoDto<UsuarioCursoRemovidoGsa>>
    {
        public ObterAlunosCursosRemovidosPorCursoIdQuery(Paginacao paginacao, string cursoId)
        {
            CursoId = cursoId;
            Paginacao = paginacao;
        }

        public string CursoId { get; set; }
        public Paginacao Paginacao { get; set; }

        public class ObterUsuariosCursosRemovidosPorCursoIdValidator : AbstractValidator<ObterAlunosCursosRemovidosPorCursoIdQuery>
        {
            public ObterUsuariosCursosRemovidosPorCursoIdValidator()
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
}
