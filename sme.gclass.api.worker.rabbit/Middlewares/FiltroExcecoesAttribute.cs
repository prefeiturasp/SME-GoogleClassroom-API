using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Worker.Rabbit.Middlewares.Results;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Worker.Rabbit.Middlewares
{
    public class FiltroExcecoesAttribute : ExceptionFilterAttribute
    {
        private readonly IMediator mediator;

        public FiltroExcecoesAttribute(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case NegocioException negocioException:
                    context.Result = new ResultadoBaseResult(context.Exception.Message, negocioException.StatusCode);
                    await SalvaLog(LogNivel.Negocio, context.Exception.Message, context.Exception.StackTrace);
                    break;

                case ValidacaoException validacaoException:
                    context.Result = new ResultadoBaseResult(new RetornoBaseDto(validacaoException.Erros));
                    await SalvaLog(LogNivel.Negocio, context.Exception.Message, context.Exception.StackTrace);
                    break;

                default:
                    context.Result = new ResultadoBaseResult("Ocorreu um erro interno. Favor contatar o suporte.", 500);
                    await SalvaLog(LogNivel.Critico, context.Exception.Message, context.Exception.StackTrace);
                    break;
            }
        }

        public Task SalvaLog(LogNivel nivel, string erro, string stackTrace)
            => mediator.Send(new SalvarLogViaRabbitCommand(erro, nivel, LogContexto.Api, rastreamento: stackTrace));
    }
}