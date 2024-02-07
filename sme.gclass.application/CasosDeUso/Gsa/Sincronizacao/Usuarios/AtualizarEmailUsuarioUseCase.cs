using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using MediatR;
using Nest;
using SME.GoogleClassroom.Aplicacao.Interfaces.CasosDeUso.Usuarios;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Dominio.SME.CDEP.Dominio.Extensions;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarEmailUsuarioUseCase : IAtualizarEmailUsuarioUseCase
    {
        const string DOMINIO_EMAIL = "edu.sme.prefeitura.sp.gov.br";
        private readonly IMediator mediator;

        public AtualizarEmailUsuarioUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar(InserirAtualizarEmailDTO filtro)
        {
            ValidarSePossuirErros(filtro);
            var usuarios = filtro.Usuarios;
            foreach (var usuario in usuarios)
                await mediator.Send(new AtualizarInserirEmailUsuarioCommand(usuario));
        }

        private static void ValidarSePossuirErros(InserirAtualizarEmailDTO filtro)
        {
            var erros = new List<string>();

            var tiposQueDevemTerId = new List<UsuarioTipo>() { UsuarioTipo.Aluno,UsuarioTipo.Professor, UsuarioTipo.Funcionario };
            var tiposQueDevemTerCpf = new List<UsuarioTipo>() { UsuarioTipo.FuncionarioIndireto };

            var qtdUsuarioQueDevemTerCpfMasEstaoSem = filtro.Usuarios.Count(x => (x.Cpf.EhNulo() || x.Email.EhNulo()) && tiposQueDevemTerCpf.Contains(x.Tipo));
            if (qtdUsuarioQueDevemTerCpfMasEstaoSem.MaiorQueZero())
                erros.Add($"Todos usuários do tipo 4 devem ter CPF e E-mail");

            var qtdUsuarioQueDevemTerIdMasEstaoSem = filtro.Usuarios.Count(x => (x.Id.EhNulo() || x.Email.EhNulo()) && tiposQueDevemTerId.Contains(x.Tipo));
            if (qtdUsuarioQueDevemTerIdMasEstaoSem.MaiorQueZero())
                erros.Add($"Todos usuários  dos tipos 1, 2, 3 devem ter Id e E-mail");

            var cpfsInvalidosOuSemId = filtro.Usuarios.Where(x => (x.Cpf.EhNulo() || x.Cpf?.Length < 11) && (x.Id.EhNulo() || x.Id.IgualZero()));
            foreach (var erro in cpfsInvalidosOuSemId)
                erros.Add($"Informe um CPF ou Id válido para o usuário {erro.Nome} ");

            var emailsInvalidos = filtro.Usuarios.Where(x => !x.Email.Contains(DOMINIO_EMAIL) || x.Email.EhNulo());
            foreach (var erro in emailsInvalidos)
                erros.Add($"Informe o E-mail valido para usuário {erro.Nome} ");

            var usuariosSemNome = filtro.Usuarios.Where(x => x.Nome.EhNulo());
            foreach (var erro in usuariosSemNome)
                erros.Add($"é necessario informar o nome de todos os usuários ");

            if (erros.PossuiElementos())
                throw new NegocioException(erros);
        }
    }
}