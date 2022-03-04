using System;
using System.Net;
using System.Threading.Tasks;
using Google;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class RemoverCursoGoogleClassroomUseCase : AbstractUseCase, IRemoverCursoGoogleClassroomUseCase
    {
        public RemoverCursoGoogleClassroomUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var codigoCurso = long.Parse(mensagemRabbit.Mensagem.ToString());
            try
            {
                var excluido = await mediator.Send(new ExcluirCursoGoogleCommand(codigoCurso));
                if (excluido)
                {
                    return await mediator.Send(new ExcluirCursoCommand(codigoCurso));
                }

                return false;
            }
            catch (GoogleApiException exception)
            {
                if (exception.HttpStatusCode == HttpStatusCode.NotFound)
                {
                    return await mediator.Send(new ExcluirCursoCommand(codigoCurso));
                }

                throw new NegocioException("Ocorreu um erro interno de comunicação comm google. Favor contatar o suporte.");
            }
            catch(Exception e)
            {
                throw new NegocioException("Ocorreu um erro interno. Favor contatar o suporte.");
            }
        }
    }
}