using SME.GoogleClassroom.Dominio;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class IniciarSyncGoogleAlunoDto
    {
        public IniciarSyncGoogleAlunoDto()
        {
        }
        public IniciarSyncGoogleAlunoDto(int? anoLetivo, List<int> tiposUes, List<long> ues, List<long> turmas, long? codigoAluno)
        {
            AnoLetivo = anoLetivo;
            TiposUes = tiposUes;
            Ues = ues;
            Turmas = turmas;
            CodigoAluno = codigoAluno;
        }

        public int? AnoLetivo { get; set; }
        public List<int> TiposUes { get; set; }
        public List<long> Ues { get; set; }
        public List<long> Turmas { get; set; }
        public long? CodigoAluno { get; set; }
        public Paginacao Paginacao { get; set; }
    }
}