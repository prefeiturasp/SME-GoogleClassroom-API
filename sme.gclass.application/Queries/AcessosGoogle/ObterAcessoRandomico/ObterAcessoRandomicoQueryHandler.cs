using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterAcessoRandomicoQueryHandler : IRequestHandler<ObterAcessoRandomicoQuery, AcessoGoogleDto>
    {
        private readonly IRepositorioAcessosGoogle repositorioAcessosGoogle;

        public ObterAcessoRandomicoQueryHandler(IRepositorioAcessosGoogle repositorioAcessosGoogle)
        {
            this.repositorioAcessosGoogle = repositorioAcessosGoogle ?? throw new ArgumentNullException(nameof(repositorioAcessosGoogle));
        }
        public async Task<AcessoGoogleDto> Handle(ObterAcessoRandomicoQuery request, CancellationToken cancellationToken)
        {
            var listaAcessos = await repositorioAcessosGoogle.Listar();

            if (listaAcessos == null || !listaAcessos.Any())
            {
                throw new NegocioException("Acessos não encontrados");
            };

            var random = new Random();

            int index = random.Next(listaAcessos.Count());
            return listaAcessos.ElementAt(index);
        }
    }
}
