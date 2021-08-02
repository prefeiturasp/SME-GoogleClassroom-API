using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterFuncionariosRemovidosCursosPorIdQuery : IRequest<PaginacaoResultadoDto<CursoUsuarioRemovidoConsultaDto>>
    {
        public ObterFuncionariosRemovidosCursosPorIdQuery(Paginacao paginacao, long cursoId)
        {
            CursoId = cursoId;
            Paginacao = paginacao;
        }

        public long CursoId { get; set; }
        public Paginacao Paginacao { get; set; }

        public class ObterFuncionariosRemovidosCursosPorIdQueryValidator : AbstractValidator<ObterFuncionariosRemovidosCursosPorIdQuery>
        {
            public ObterFuncionariosRemovidosCursosPorIdQueryValidator()
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
