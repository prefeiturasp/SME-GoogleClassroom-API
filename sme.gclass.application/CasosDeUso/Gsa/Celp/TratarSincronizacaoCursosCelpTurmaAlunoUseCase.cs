using System;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarSincronizacaoCursosCelpTurmaAlunoUseCase : ITratarSincronizacaoCursosCelpTurmaAlunoUseCase
    {
        private readonly IMediator mediator;

        public TratarSincronizacaoCursosCelpTurmaAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagem)
        {
            if (mensagem.Mensagem == null)
                throw new NegocioException("Não foi possível iniciar a sincronização com GSA dos alunos da turma do CELP.");

            var filtro = mensagem.ObterObjetoMensagem<FiltroSincronizacaoCursosCelpTurmaAlunoDto>();
        }
    }
}