using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao.Queries
{
    public class
        ObterAlunosAtivosPorCodigoTurmaQueryHandler : IRequestHandler<ObterAlunosAtivosPorCodigoTurmaQuery, IEnumerable<AlunoEolSimplificadoDto>>
    {
        private readonly IRepositorioAlunoEol repositorio;

        public ObterAlunosAtivosPorCodigoTurmaQueryHandler(IRepositorioAlunoEol repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<IEnumerable<AlunoEolSimplificadoDto>> Handle(ObterAlunosAtivosPorCodigoTurmaQuery request,
            CancellationToken cancellationToken)
        {
            var retorno = await repositorio.ObterAlunosAtivosPorTurmaCodigo(request.CodigoTurma);
            return retorno?.Select(aluno => new AlunoEolSimplificadoDto{ Codigo = aluno.CodigoAluno, DataNascimento = aluno.DataNascimento, Nome = aluno.NomeAluno } );
        }
    }
}