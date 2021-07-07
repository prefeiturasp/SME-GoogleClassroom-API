using System;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterAvisoDto: FiltroPaginacaoBaseDto
    {
        public DateTime DataReferencia { get; set; }
        public string UsuarioId { get; set; }
        public long? CursoId { get; set; }
    }
}
