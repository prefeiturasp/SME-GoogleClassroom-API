using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Infra
{

    public class NotaSgpDto
    {
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long AtividadeGoogleClassroomId { get; set; }
        public StatusGSA StatusGsa { get; set; }
        public double? Nota { get; set; }
        public DateTime? DataEntregaAvaliacao { get; set; }
        public long CodigoAluno { get; set; }

        public NotaSgpDto(long turmaId, long componenteCurricularId, long atividadeGoogleClassroomId,
            StatusGSA statusGsa, double? nota, DateTime? dataEntregaAvaliacao, long codigoAluno)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            AtividadeGoogleClassroomId = atividadeGoogleClassroomId;
            StatusGsa = statusGsa;
            Nota = nota;
            DataEntregaAvaliacao = dataEntregaAvaliacao;
            CodigoAluno = codigoAluno;
        }
    }
}
