using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Commands
{
    public class GravarNotaGsaCommandHandler : AsyncRequestHandler<GravarNotaGsaCommand>
    {
        private readonly IRepositorioNota repositorioNota;

        public GravarNotaGsaCommandHandler(IRepositorioNota repositorioNota)
        {
            this.repositorioNota = repositorioNota ?? throw new ArgumentNullException(nameof(repositorioNota));
        }

        protected async override Task Handle(GravarNotaGsaCommand request, CancellationToken cancellationToken)
        {
            var notaGsa = MapearEntidade(
                     request.Id,
                     request.AtividadeId,
                     request.UsuarioId,
                     request.Nota,
                     request.Status,
                     request.DataInclusao,
                     request.DataAlteracao);

            if (await RegistroExistente(request.Id))
                await repositorioNota.AlterarNota(notaGsa);
            else
                await repositorioNota.InserirNota(notaGsa);
        }

        private NotaGsa MapearEntidade(string id, long atividadeId, string usuarioId, double? nota, StatusGSA status, DateTime dataInclusao, DateTime? dataAlteracao)
            => new NotaGsa(id, atividadeId, usuarioId, status, nota, DateTime.Now, dataInclusao, dataAlteracao);

        private async Task<bool> RegistroExistente(string id)
            => await repositorioNota.RegistroExiste(id);
    }
}
