using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Dominio.SME.CDEP.Dominio.Extensions;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizarEmailUsuarioUseCase : IAtualizarEmailUsuarioUseCase
    {
        private readonly IMediator mediator;

        public AtualizarEmailUsuarioUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Executar(InserirAtualizarEmailDTO filtro)
        {
            ValidarSePossuirErros(filtro);

            var idsConsulta = filtro.Usuarios.Select(u => u.Id);
            var usuariosExistentes = await mediator.Send(new ObterUsuariosPorIdsQuery(idsConsulta.ToArray()));
            var idsParaAtualizar = usuariosExistentes.Select(x => Convert.ToInt64(x.Id));
            var idsParaInserir = idsConsulta.Except(idsParaAtualizar);
            await AtualizarUsuarios(filtro.Usuarios.Where(x => idsParaAtualizar.Contains(x.Id)));
            await InserirUsuarios(filtro.Usuarios.Where(x => idsParaInserir.Contains(x.Id)));
        }

        private static void ValidarSePossuirErros(InserirAtualizarEmailDTO filtro)
        {
            var erros = new List<string>();
            
            var cpfsNulos = filtro.Usuarios.Where(x => x.Cpf.EhNulo() || x.Cpf?.Length < 11);
            foreach(var erro in cpfsNulos)
                erros.Add($"Informe um CPF válido para o usuário {erro.Nome} ");

            var emailsNulos = filtro.Usuarios.Where(x => x.Email.EhNulo());
            foreach(var erro in emailsNulos)
                erros.Add($"Informe o E-mail do usuário {erro.Nome} ");
            
            if (erros.PossuiElementos())
                throw new NegocioException(erros);
        }

        private async Task AtualizarUsuarios(IEnumerable<UsuarioEmailDto> usuarios)
        {
            foreach (var usuario in usuarios)
                await mediator.Send(new AtualizarUsuarioPorIdCommand(usuario.Id,usuario.Nome,usuario.Cpf,usuario.Email,(int)usuario.UsuarioTipo));
        }
        private async Task InserirUsuarios(IEnumerable<UsuarioEmailDto> usuarios)
        {
            foreach (var usuario in usuarios)
                await mediator.Send(new IncluirUsuarioCommand(usuario.Id,usuario.Cpf,usuario.Nome,usuario.Email));
        }
    }
}