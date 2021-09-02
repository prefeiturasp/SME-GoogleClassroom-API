using MediatR;
using SME.GoogleClassroom.Dados.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ComponenteLancaNotaQueryHandler : IRequestHandler<ComponenteLancaNotaQuery, bool>
    {
        private readonly IRepositorioComponenteCurricular repositorioComponenteCurricular;

        public ComponenteLancaNotaQueryHandler(IRepositorioComponenteCurricular repositorioComponenteCurricular)
        {
            this.repositorioComponenteCurricular = repositorioComponenteCurricular ?? throw new ArgumentNullException(nameof(repositorioComponenteCurricular));
        }

        public async Task<bool> Handle(ComponenteLancaNotaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioComponenteCurricular.LancaNota(request.ComponenteCurricularId);
        }
    }
}
