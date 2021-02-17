﻿using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Sentry;
using SME.GoogleClassroom.Infra;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public  class PublicaFilaWorkerServidorRelatoriosCommandHandler : IRequestHandler<PublicaFilaWorkerServidorRelatoriosCommand, bool>
    {
        private readonly IModel rabbitChannel;

        public PublicaFilaWorkerServidorRelatoriosCommandHandler(IModel rabbitChannel)
        {
            this.rabbitChannel = rabbitChannel ?? throw new ArgumentNullException(nameof(rabbitChannel));
        }

        public Task<bool> Handle(PublicaFilaWorkerServidorRelatoriosCommand request, CancellationToken cancellationToken)
        {
            byte[] body = FormataBodyWorker(request);

            rabbitChannel.QueueBind(RotasRabbit.WorkerRelatoriosSgp, RotasRabbit.ExchangeServidorRelatorios, RotasRabbit.RotaRelatoriosSolicitados);
            rabbitChannel.BasicPublish(RotasRabbit.ExchangeServidorRelatorios, request.Fila, null, body);

            SentrySdk.CaptureMessage("3 - AdicionaFilaWorkerRelatorios");

            return Task.FromResult(true);
        }

        private static byte[] FormataBodyWorker(PublicaFilaWorkerServidorRelatoriosCommand request)
        {
            var mensagem = new MensagemRabbit(request.Endpoint, request.Mensagem, request.CodigoCorrelacao, request.UsuarioLogadoRF, request.NotificarErroUsuario, request.PerfilUsuario);
            var mensagemJson = JsonConvert.SerializeObject(mensagem);
            var body = Encoding.UTF8.GetBytes(mensagemJson);
            return body;
        }
    }
}
