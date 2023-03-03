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
        private readonly IRepositorioElasticTurma repositorioElasticSearch;

        public ObterAlunosAtivosPorCodigoTurmaQueryHandler(IRepositorioElasticTurma repositorioElasticSearch)
        {
            this.repositorioElasticSearch = repositorioElasticSearch ?? throw new ArgumentNullException(nameof(repositorioElasticSearch));
        }

        public async Task<IEnumerable<AlunoEolSimplificadoDto>> Handle(ObterAlunosAtivosPorCodigoTurmaQuery request,
            CancellationToken cancellationToken)
        {
            var retornoElastic = await repositorioElasticSearch.ObterAlunosAtivosNaTurmaAsync((int)request.CodigoTurma, DateTime.Today);
            return retornoElastic?.Select(aluno => new AlunoEolSimplificadoDto { Codigo = aluno.CodigoAluno, DataNascimento = aluno.DataNascimento, Nome = aluno.NomeSocialAluno ?? aluno.NomeAluno });
        }
    }
}