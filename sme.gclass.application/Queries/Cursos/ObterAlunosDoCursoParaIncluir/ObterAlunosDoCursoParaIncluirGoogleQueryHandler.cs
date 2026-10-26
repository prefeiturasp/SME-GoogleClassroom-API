using MediatR;
using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dados.Interfaces;
using SME.GoogleClassroom.Infra.Dtos.Curso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Queries.Cursos.ObterAlunosDoCursoParaIncluir
{
    public class ObterAlunosDoCursoParaIncluirGoogleQueryHandler : IRequestHandler<ObterAlunosDoCursoParaIncluirGoogleQuery, IEnumerable<AlunoCursoParaIncluirGoogleDto>>
    {
        private readonly IRepositorioCursoEol repositorioCursoEol;
        private readonly IRepositorioCursoUsuario repositorioCursoUsuario;

        public ObterAlunosDoCursoParaIncluirGoogleQueryHandler(IRepositorioCursoEol repositorioCursoEol, IRepositorioCursoUsuario repositorioCursoUsuario)
        {
            this.repositorioCursoEol = repositorioCursoEol ?? throw new ArgumentNullException(nameof(repositorioCursoEol));
            this.repositorioCursoUsuario = repositorioCursoUsuario ?? throw new ArgumentNullException(nameof(repositorioCursoUsuario));
        }

        public async Task<IEnumerable<AlunoCursoParaIncluirGoogleDto>> Handle(ObterAlunosDoCursoParaIncluirGoogleQuery request, CancellationToken cancellationToken)
        {
            var alunosEol = (await repositorioCursoEol.ObterAlunosDoCursoParaIncluirAsync(
                request.AnoLetivo,
                request.TurmaId,
                request.ComponenteCurricularId,
                request.ParametrosCargaInicialDto)).ToList();

            if (!alunosEol.Any())
                return alunosEol;

            // Exclui os alunos que já estão no curso no Google (bancos diferentes, filtro em memória)
            var sincronizados = (await repositorioCursoUsuario.ObterCodigosAlunosSincronizadosNoCursoAsync(
                request.TurmaId,
                request.ComponenteCurricularId)).ToHashSet();

            return alunosEol.Where(a => !sincronizados.Contains(a.CodigoAluno)).ToList();
        }
    }
}