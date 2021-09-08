using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Infra
{
    public class NotasAtividadesDto
    {
        public string Id { get; set; }
        public string DataAvaliacao { get; set; }
        public string Titulo { get; set; }
        public long AtividadeId { get; set; }
        public long UsuarioId { get; set; }
        public double Nota { get; set; }
        public StatusGSA Status { get; set; }
        public string CursoNome { get; set; }
        public string CursoSecao { get; set; }
        public DateTime DataImportacao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
