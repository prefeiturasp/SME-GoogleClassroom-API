using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosParaArquivarPorAnoPaginadoQuery : IRequest<PaginacaoResultadoDto<CursoArquivarEolDto>>
    {
        public int AnoLetivo { get; }
        public int? Semestre { get; }
        public Paginacao Paginacao { get; }

        public ObterCursosParaArquivarPorAnoPaginadoQuery(int anoLetivo, int? semestre, Paginacao paginacao)
        {
            AnoLetivo = anoLetivo;
            Semestre = semestre;
            Paginacao = paginacao;
        }
    }

    public class ObterCursosParaArquivarPorAnoPaginadoQueryValidator : AbstractValidator<ObterCursosParaArquivarPorAnoPaginadoQuery>
    {
        public ObterCursosParaArquivarPorAnoPaginadoQueryValidator()
        {
            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano letivo deve ser informado para consulta de turmas a arquivar");
        }
    }
}
