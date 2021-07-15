using SME.GoogleClassroom.Dados;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterDadosTesteUseCase : IObterDadosTesteUseCase
    {
        private readonly IRepositorioCurso repositorioCurso; 
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterDadosTesteUseCase(IRepositorioCurso repositorioCurso, IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioCurso = repositorioCurso ?? throw new ArgumentNullException(nameof(repositorioCurso));
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new ArgumentNullException(nameof(repositorioAlunoEol));
        }

        public async Task<IEnumerable<CursoGoogle>> Executar(int satus)
        {
            var turmasId = await repositorioAlunoEol.ObterTurmasTeste(satus);
            return await repositorioCurso.ObterCursosPorTurmas(turmasId);
        }
    }
}
