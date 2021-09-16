using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosParaArquivarPorAnoPaginadoQuery : IRequest<PaginacaoResultadoDto<CursoArquivarEolDto>>
    {
        public int AnoLetivo { get; }
        public Paginacao Paginacao { get; }
        public ParametrosCargaInicialDto ParametrosCargaInicialDto { get; set; }

        public ObterCursosParaArquivarPorAnoPaginadoQuery(int anoLetivo, Paginacao paginacao, ParametrosCargaInicialDto parametrosCargaInicialDto)
        {
            AnoLetivo = anoLetivo;
            Paginacao = paginacao;
            ParametrosCargaInicialDto = parametrosCargaInicialDto;
        }
    }

    public class ObterCursosParaArquivarPorAnoPaginadoQueryValidator : AbstractValidator<ObterCursosParaArquivarPorAnoPaginadoQuery>
    {
        public ObterCursosParaArquivarPorAnoPaginadoQueryValidator()
        {
            RuleFor(x => x.ParametrosCargaInicialDto)
                .NotEmpty()
                .WithMessage("A configuração de parâmetros deve ser informada.");

            RuleFor(a => a.AnoLetivo)
                .NotEmpty()
                .WithMessage("O ano letivo deve ser informado para consulta de turmas a arquivar");
        }
    }
}
