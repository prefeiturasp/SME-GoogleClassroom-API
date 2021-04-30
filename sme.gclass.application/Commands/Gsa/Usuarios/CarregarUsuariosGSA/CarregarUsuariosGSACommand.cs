using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class CarregarUsuariosGSACommand : IRequest<bool>
    {
        public CarregarUsuariosGSACommand(string tokenPagina)
        {
            TokenPagina = tokenPagina;
        }

        public string TokenPagina { get; }
    }
}
