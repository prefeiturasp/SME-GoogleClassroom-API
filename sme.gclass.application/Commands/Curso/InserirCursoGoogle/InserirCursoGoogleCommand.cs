using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoGoogleCommand : IRequest<bool>
    {
        public InserirCursoGoogleCommand(CursoParaInclusaoDto cursoParaInclusao)
        {
            CursoParaInclusao = cursoParaInclusao;
        }

        public CursoParaInclusaoDto CursoParaInclusao { get; set; }
    }
}
