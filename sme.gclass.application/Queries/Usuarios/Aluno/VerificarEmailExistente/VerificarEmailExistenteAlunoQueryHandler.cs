using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class VerificarEmailExistenteAlunoQueryHandler : IRequestHandler<VerificarEmailExistenteAlunoQuery, AlunoEol>
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        public VerificarEmailExistenteAlunoQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<AlunoEol> Handle(VerificarEmailExistenteAlunoQuery request, CancellationToken cancellationToken)
        {
            return await ObterEmailValido(request.AlunoEol);
        }

        private async Task<AlunoEol> ObterEmailValido(AlunoEol aluno, int tentativa = 0)
        {
            aluno.DefinirEmail(tentativa);
            var emailExistente = await repositorioUsuario.ExisteEmailUsuarioPorTipo(aluno.Email, UsuarioTipo.Aluno);

            if (!emailExistente)
                return aluno;
            else
                return await ObterEmailValido(aluno, tentativa + 1);

        }
    }
}