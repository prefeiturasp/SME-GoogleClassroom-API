using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarArquivamentoCursosUseCase : AbstractUseCase, ITratarArquivamentoCursosUseCase
    {
        public TratarArquivamentoCursosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            if (mensagem?.Mensagem is null)
                throw new NegocioException("Não foi possível tratar a exinção de turmas. Mensagem não recebida");

            var dto = mensagem.ObterObjetoMensagem<ArquivarTurmaDto>();

            try
            {
                var cursos = await mediator.Send(new ObterIdsCursosPorTurmaQuery(dto.TurmaId));

                foreach (var cursoId in cursos)
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoArquivarSync, new ArquivarCursoDto(cursoId, dto.DataExtincao, dto.Excluir)));
            }
            catch (Exception)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoArquivarTratarErro, dto));
            }
            return true;
        }
    }
}
