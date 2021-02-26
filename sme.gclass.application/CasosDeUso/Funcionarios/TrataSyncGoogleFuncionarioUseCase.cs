using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Funcionarios;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataSyncGoogleFuncionarioUseCase : ITrataSyncGoogleFuncionarioUseCase
    {
        private readonly IMediator mediator;

        public TrataSyncGoogleFuncionarioUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Executar(MensagemRabbit mensagem)
        {
            var ultimaAtualizacao = DateTime.Now;

            var paginacao = new Paginacao(0, 0);
            var funcionariosParaIncluirGoogle = await mediator.Send(new ObterFuncionariosParaIncluirGoogleQuery(ultimaAtualizacao, paginacao));
            foreach(var funcionarioParaIncluirGoogle in funcionariosParaIncluirGoogle)
            {

            }


        }
    }
}