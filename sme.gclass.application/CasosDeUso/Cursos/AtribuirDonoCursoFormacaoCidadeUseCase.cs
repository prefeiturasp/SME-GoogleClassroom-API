using Google;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtribuirDonoCursoFormacaoCidadeUseCase : IAtribuirDonoCursoFormacaoCidadeUseCase
    {
        private readonly IMediator mediator;

        public AtribuirDonoCursoFormacaoCidadeUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(string email, string nome)
        {
            var curso = await mediator.Send(new ObterCursoPorEmailNomeQuery(email, nome));
            if (curso == null)
                throw new NegocioException("Não foi possível alterar o dono do curso, pois o curso não existe na base do GSA");
            try
            {
                var usuario = await mediator.Send(new ObterUsuarioGoogleQuery(email));
                var retornoGoogle = await mediator.Send(new AtribuirDonoCursoGoogleCommand(curso.Id, usuario.Id));
                if (retornoGoogle) { 
                    curso.Email = email;
                    await mediator.Send(new AlterarCursoCommand(curso));
                }
                return retornoGoogle;
            }
            catch (GoogleApiException gEx)
            {
                if (gEx.RegistroNaoEncontrado()) throw new NegocioException("Usuário não existe no Google Classroom");
                else if(gEx.AcessoNaoAutorizado()) throw new NegocioException("Usuário sem acesso ao Google Classroom");
                else if (gEx.EmailContaServicoInvalido()) throw new NegocioException("Email informado é inválido");
                else
                    throw new NegocioException(gEx.Message);
            }
        }
    }
}
