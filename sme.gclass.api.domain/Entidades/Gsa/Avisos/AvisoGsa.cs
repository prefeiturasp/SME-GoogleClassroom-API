using System;

namespace SME.GoogleClassroom.Dominio
{
    public class AvisoGsa
    {
        public long Id { get; set; }
        public string Texto { get; set; }
        public string UsuarioGsaId { get;  set; }
        public long CursoGsaId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public AvisoGsa()
        {
        }

        public AvisoGsa(long id, string texto, string usuarioGsaId, long cursoId, DateTime dataInclusao, DateTime dataAlteracao)
        {
            Id = id;
            Texto = texto;
            UsuarioGsaId = usuarioGsaId;
            CursoGsaId = cursoId;
            DataInclusao = dataInclusao;
            DataAlteracao = dataAlteracao;
        }
    }
}