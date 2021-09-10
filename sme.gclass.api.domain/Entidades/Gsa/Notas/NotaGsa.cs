using System;

namespace SME.GoogleClassroom.Dominio
{
    public class NotaGsa
    {
        public NotaGsa() { }

        public NotaGsa(string id, long atividadeId, string usuarioClassroomId, StatusGSA status, double? nota, DateTime dataImportacao, DateTime dataInclusao, DateTime? dataAlteracao = null)
        {
            Id = id;
            AtividadeId = atividadeId;
            UsuarioClassroomId = usuarioClassroomId;
            Status = status;
            Nota = nota;
            DataImportacao = dataImportacao;
            DataInclusao = dataInclusao;
            DataAlteracao = dataAlteracao;
        }

        public string Id { get; set; }
        public long AtividadeId { get; set; }
        public string UsuarioClassroomId { get; set; }
        public StatusGSA Status { get; set; }
        public double? Nota { get; set; }
        public DateTime DataImportacao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
