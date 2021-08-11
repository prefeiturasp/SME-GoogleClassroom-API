using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Usuarios.Erros.ObterProfessorParaTratamentoDeErro
{
    public class ObterProfessorParaTratamentoDeErroQueryHandler : IRequestHandler<ObterProfessorParaTratamentoDeErroQuery, ProfessorEol>
    {
        private readonly IRepositorioProfessorEol repositorioProfessorEol;

        public ObterProfessorParaTratamentoDeErroQueryHandler(IRepositorioProfessorEol repositorioProfessorEol)
        {
            this.repositorioProfessorEol = repositorioProfessorEol;
        }

        public async Task<ProfessorEol> Handle(ObterProfessorParaTratamentoDeErroQuery request, CancellationToken cancellationToken)
            => await repositorioProfessorEol.ObterProfessorParaTratamentoDeErroAsync(request.Rf, DateTime.Now.Year);
    }
}