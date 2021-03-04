﻿using MediatR;
using Newtonsoft.Json;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirAlunoUseCase : IIncluirAlunoUseCase
    {
        private readonly IMediator mediator;

        public IncluirAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var alunoParaIncluir = JsonConvert.DeserializeObject<AlunoEol>(mensagemRabbit.Mensagem.ToString());
            if (alunoParaIncluir is null) return true;

            try
            {
                // TO DO: Remover ao subir para produção
                //var alunoJaIncluido = await mediator.Send(new ExisteAlunoPorRfQuery(alunoParaIncluir.Codigo));
                //if (alunoJaIncluido) return true;

                //var alunoGoogle = new AlunoGoogle(alunoParaIncluir.Codigo, alunoParaIncluir.Nome, alunoParaIncluir.Email, alunoParaIncluir.CaminhoOrganizacao);
                //await mediator.Send(new InserirAlunoGoogleCommand(alunoGoogle));
                //await mediator.Send(new IncluirUsuarioCommand(alunoGoogle);

                await Task.Delay(10000);
                return true;
            }
            catch (Exception ex)
            {
                await mediator.Send(new IncluirUsuarioErroCommand(alunoParaIncluir?.Codigo, alunoParaIncluir?.Email,
                    $"ex.: {ex.Message} <-> msg rabbit: {mensagemRabbit}", UsuarioTipo.Funcionario, ExecucaoTipo.FuncionarioAdicionar, DateTime.Now));
                throw;
            }
        }
    }
}