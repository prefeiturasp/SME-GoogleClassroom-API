using MediatR;
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
            var resposta = JsonConvert.DeserializeObject<AlunoParaInclusaoDto>(mensagemRabbit.Mensagem.ToString());

            if (resposta != null)
            {
                var alunoExistente = await mediator.Send(new ExisteAlunoPorRfQuery(resposta.Codigo));

                if (!alunoExistente)
                {
                    var alunoEol = MapearAlunoDtoParaDominio(resposta);

                    alunoEol  = await mediator.Send(new VerificarEmailExistenteAlunoQuery(alunoEol));
                }
            }

            return true;
        }

        private AlunoEol MapearAlunoDtoParaDominio(AlunoParaInclusaoDto resposta)
        {
            return new AlunoEol(resposta.Codigo, resposta.Nome, resposta.CaminhoOrganizacao, resposta.DataNascimento);
        }
    }
}
