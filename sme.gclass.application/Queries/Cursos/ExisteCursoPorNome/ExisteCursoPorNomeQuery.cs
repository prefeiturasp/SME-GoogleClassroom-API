using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteCursoPorNomeQuery : IRequest<long>
    {
        public ExisteCursoPorNomeQuery(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
