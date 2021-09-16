using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAvisoQuery : IRequest<PaginacaoResultadoDto<AvisoGsa>>
    {
        public ObterAvisoQuery(Paginacao paginacao, DateTime dataReferencia, string usuarioId, long? cursoId)
        {
            Paginacao = paginacao;
            DataReferencia = dataReferencia;
            UsuarioId = usuarioId;
            CursoId = cursoId;
        }

        public Paginacao Paginacao { get; set; }
        public DateTime DataReferencia { get; set; }
        public string UsuarioId { get; set; }
        public long? CursoId { get; set; }
    }

    public class ObterAvisoQueryValidator : AbstractValidator<ObterAvisoQuery>
    {
        public ObterAvisoQueryValidator()
        {
            RuleFor(x => x.DataReferencia)
                .NotEmpty()
                .WithMessage("Parâmetro data de referência não pode ser nulo");
        }
    }
}