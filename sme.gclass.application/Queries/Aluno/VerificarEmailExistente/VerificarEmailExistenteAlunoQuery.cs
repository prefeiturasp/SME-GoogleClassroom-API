using MediatR;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Aplicacao
{
    public  class VerificarEmailExistenteAlunoQuery : IRequest<AlunoEol>
    {
        public VerificarEmailExistenteAlunoQuery(AlunoEol alunoEol)
        {
            AlunoEol = alunoEol;
        }

        public AlunoEol AlunoEol { get; set; }
    }
}
