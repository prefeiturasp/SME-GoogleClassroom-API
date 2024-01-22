using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
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
            var idsConsulta = filtro.Usuarios.Select(u => u.Id);
            var usuariosExistentes = await mediator.Send(new ObterUsuariosPorIdsQuery(idsConsulta.ToArray()));
            var idsParaAtualizar = usuariosExistentes.Select(x => Convert.ToInt64(x.Id));
            var idsParaInserir = idsConsulta.Except(idsParaAtualizar);
            await AtualizarUsuarios(filtro.Usuarios.Where(x => idsParaAtualizar.Contains(x.Id)));
            await InserirUsuarios(filtro.Usuarios.Where(x => idsParaInserir.Contains(x.Id)));
        }

        private async Task AtualizarUsuarios(IEnumerable<UsuarioEmailDto> usuarios)
        {
            //AtualizarUsuarioCommand
        }
        private async Task InserirUsuarios(IEnumerable<UsuarioEmailDto> usuarios)
        {
            //AtualizarUsuarioCommand
        }
    }
}