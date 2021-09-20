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
        public DateTime DataInclusao { get; set; }
        public DateTime? DataEntregaAvaliacao { get; set; }
        public string CodigoAluno { get; set; }
        public string Titulo { get; set; }

        public NotaSgpDto(long turmaId, long componenteCurricularId, long atividadeGoogleClassroomId,
            StatusGSA statusGsa, double? nota, DateTime dataInclusao, DateTime? dataEntregaAvaliacao, string codigoAluno, string titulo)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            AtividadeGoogleClassroomId = atividadeGoogleClassroomId;
            StatusGsa = statusGsa;
            Nota = nota;
            DataInclusao = dataInclusao;
            DataEntregaAvaliacao = dataEntregaAvaliacao;
            CodigoAluno = codigoAluno;
            Titulo = titulo;
        }
    }
}
