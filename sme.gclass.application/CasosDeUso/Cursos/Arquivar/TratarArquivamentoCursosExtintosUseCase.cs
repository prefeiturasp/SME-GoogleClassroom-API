using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarArquivamentoCursosExtintosUseCase : AbstractUseCase, ITratarArquivamentoCursosExtintosUseCase
    {
        public TratarArquivamentoCursosExtintosUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            if (mensagem?.Mensagem is null)
                throw new NegocioException("Não foi possível tratar a exinção de turmas. Mensagem não recebida");

            var dto = mensagem.ObterObjetoMensagem<ArquivarTurmaExtintaDto>();

            try
            {
                var cursos = await mediator.Send(new ObterIdsCursosPorTurmaQuery(dto.TurmaId));
                foreach (var cursoId in cursos)
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoExtintoArquivarSync, new ArquivarCursoExtintoDto(cursoId, dto.DataExtincao, dto.Excluir)));

            }
            catch (System.Exception ex)
            {
                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaCursoExtintoArquivarTratarErro, dto));
            }
            return true;
        }
    }
}
