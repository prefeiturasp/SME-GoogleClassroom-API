using MediatR;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class IncluirCursoCommand : IRequest<bool>
    {
        public IncluirCursoCommand(CursoParaInclusaoDto cursoParaInclusao)
        {
            CursoParaInclusao = cursoParaInclusao;
        }

        public CursoParaInclusaoDto CursoParaInclusao { get; set; }
    }
}
