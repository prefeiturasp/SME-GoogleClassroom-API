using MediatR;
using Sentry;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarProfessoresInativosGsaUseCase : ITratarProfessoresInativosGsaUseCase
    {
        private readonly IMediator mediator;

        public TratarProfessoresInativosGsaUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<FiltroProfessoresInativosDto>();
            
            var professoresEFuncionariosGoogle = await mediator.Send(new ObterProfessoresEFuncionariosPorCodigosQuery(dto.Ids.ToArray()));

            if (professoresEFuncionariosGoogle != null && professoresEFuncionariosGoogle.Any())
            {
                foreach (var professor in professoresEFuncionariosGoogle)
                {
                    var professorFuncionarioInativar = new ProfessorInativoDto(professor.Rf, professor.Indice, professor.Email, 1);
                    await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaInativarProfessorIncluir, professorFuncionarioInativar));
                }
                return true;
            }
            else
            {
                SentrySdk.CaptureMessage($"Não foi possível localizar os usuários (professores / funcionários) pelos códigos {string.Join(", ", dto.Ids.ToArray())} no GSA");
                return false;
            }
        }
    }
}
