using MediatR;
using Moq;
using SME.GoogleClassroom.Aplicacao;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.GoogleClassroom.Testes.Unitario.Aplicacao.Queries.Usuarios.Alunos
{
    public class VerificarEmailExistenteAlunoQueryTeste
    {
        private readonly Mock<IRepositorioUsuario> repositorioUsuario;
        private readonly IRequestHandler<VerificarEmailExistenteAlunoQuery, AlunoEol> verificarEmailExistenteAlunoQueryHandler;

        public VerificarEmailExistenteAlunoQueryTeste()
        {
            repositorioUsuario = new Mock<IRepositorioUsuario>();
            verificarEmailExistenteAlunoQueryHandler = new VerificarEmailExistenteAlunoQueryHandler(repositorioUsuario.Object);
        }

        [Fact(DisplayName = "Valida o tratamento de e-mail duplicado para aluno até a útlima tentativa.")]
        private async Task Valida_Tratamento_De_Duplicidade_De_Email_Ate_A_Ultima_Tentativa_Deve_Retornar_O_Email_Alterado()
        {
            // Arrange
            var aluno = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));

            var email = aluno.Email;
            var emailTentativa1 = "jose.silva.10091990@edu.sme.prefeitura.sp.gov.br";
            var emailTentativa2 = "jose_silva.10091990@edu.sme.prefeitura.sp.gov.br";
            var emailTentativa3 = "jose-silva.10091990@edu.sme.prefeitura.sp.gov.br";

            repositorioUsuario.Setup(x => x.ExisteEmailUsuarioPorTipo(email, UsuarioTipo.Aluno, aluno.Codigo))
                .ReturnsAsync(true);

            repositorioUsuario.Setup(x => x.ExisteEmailUsuarioPorTipo(emailTentativa1, UsuarioTipo.Aluno, aluno.Codigo))
                .ReturnsAsync(true);

            repositorioUsuario.Setup(x => x.ExisteEmailUsuarioPorTipo(emailTentativa2, UsuarioTipo.Aluno, aluno.Codigo))
                .ReturnsAsync(true);

            repositorioUsuario.Setup(x => x.ExisteEmailUsuarioPorTipo(emailTentativa3, UsuarioTipo.Aluno, aluno.Codigo))
                .ReturnsAsync(false);

            var query = new VerificarEmailExistenteAlunoQuery(aluno);

            // Act
            var alunoRetorno = await verificarEmailExistenteAlunoQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(alunoRetorno);
            Assert.Equal(emailTentativa3, alunoRetorno.Email);
        }

        [Fact(DisplayName = "Valida o tratamento de e-mail duplicado para aluno até a útlima tentativa.")]
        private async Task Valida_Tratamento_De_Duplicidade_De_Email_Nao_Encontrando_Email_Valido_Deve_Disparar_Excecao()
        {
            // Arrange
            var aluno = new AlunoEol(1, "José da Silva", string.Empty, string.Empty, new DateTime(1990, 9, 10));

            var email = aluno.Email;
            var emailTentativa1 = "jose.silva.10091990@edu.sme.prefeitura.sp.gov.br";
            var emailTentativa2 = "jose_silva.10091990@edu.sme.prefeitura.sp.gov.br";
            var emailTentativa3 = "jose-silva.10091990@edu.sme.prefeitura.sp.gov.br";

            repositorioUsuario.Setup(x => x.ExisteEmailUsuarioPorTipo(email, UsuarioTipo.Aluno, aluno.Codigo))
                .ReturnsAsync(true);

            repositorioUsuario.Setup(x => x.ExisteEmailUsuarioPorTipo(emailTentativa1, UsuarioTipo.Aluno, aluno.Codigo))
                .ReturnsAsync(true);

            repositorioUsuario.Setup(x => x.ExisteEmailUsuarioPorTipo(emailTentativa2, UsuarioTipo.Aluno, aluno.Codigo))
                .ReturnsAsync(true);

            repositorioUsuario.Setup(x => x.ExisteEmailUsuarioPorTipo(emailTentativa3, UsuarioTipo.Aluno, aluno.Codigo))
                .ReturnsAsync(true);

            var query = new VerificarEmailExistenteAlunoQuery(aluno);

            // Assert
            await Assert.ThrowsAsync< NegocioException>(() => verificarEmailExistenteAlunoQueryHandler.Handle(query, CancellationToken.None));
        }
    }
}
