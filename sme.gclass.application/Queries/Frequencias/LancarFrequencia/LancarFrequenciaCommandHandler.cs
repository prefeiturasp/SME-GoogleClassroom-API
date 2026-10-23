using System;
using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class LancarFrequenciaCommandHandler : IRequestHandler<LancarFrequenciaCommand, bool>
    {
        private readonly IMediator mediator;

        public LancarFrequenciaCommandHandler(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        public async Task<bool> Handle(LancarFrequenciaCommand request, CancellationToken cancellationToken)
        {
            if (request.FrequenciaSalvarAulaAlunos == null)
                throw new NegocioException("Não foi possível realizar o lançamento da frequência.");

            var frequenciaSalvarAulaAlunos = request.FrequenciaSalvarAulaAlunos;
            
            var frequencia = new FrequenciaDto(frequenciaSalvarAulaAlunos.AulaId);

            if (frequenciaSalvarAulaAlunos.Alunos != null)
            {
                foreach (var frequenciaAluno in frequenciaSalvarAulaAlunos.Alunos)
                {
                    frequencia.ListaFrequencia.Add(new RegistroFrequenciaAlunoDto()
                    {
                        CodigoAluno = frequenciaAluno.CodigoAluno,
                        Aulas = frequenciaAluno.Frequencias?.ToList()
                    });
                }
            }

            var publicado = await mediator.Send(new PublicaFilaRabbitSgpCommand(RotasRabbitSgp.RotaFrequenciaLancamentoAulaSync, frequencia, frequenciaSalvarAulaAlunos.UsuarioLogado, string.Empty, frequenciaSalvarAulaAlunos.PerfilUsuario));
            if (!publicado)
                throw new NegocioException("Não foi possível realizar o lançamento da frequência.");

            return publicado;
        }
    }
}
