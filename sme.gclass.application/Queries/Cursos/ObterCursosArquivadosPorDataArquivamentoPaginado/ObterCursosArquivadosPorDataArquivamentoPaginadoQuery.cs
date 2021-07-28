using System;
using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterCursosArquivadosPorDataArquivamentoPaginado
{
    public class ObterCursosArquivadosPorDataArquivamentoPaginadoQuery: IRequest<PaginacaoResultadoDto<CursoArquivadoDto>>
    {
        public DateTime DataArquivamento { get; }
        public Paginacao paginacao { get; }

        public ObterCursosArquivadosPorDataArquivamentoPaginadoQuery(DateTime dataArquivamento, Paginacao paginacao)
        {
            DataArquivamento = dataArquivamento;
        }
    }

    public class ObterCursosArquivadosPorDataArquivamentoPaginadoQueryValidator : AbstractValidator<ObterCursosArquivadosPorDataArquivamentoPaginadoQuery>
    {
        public ObterCursosArquivadosPorDataArquivamentoPaginadoQueryValidator()
        {
            RuleFor(a => a.DataArquivamento)
                .NotEmpty()
                .WithMessage("A data de início deve ser informada para consulta de cursos arquivados");

        }
    }
}