using System;

namespace SME.GoogleClassroom.Infra
{
    public class ArquivarCursoDto
    {
        public ArquivarCursoDto(long cursoId, DateTime dataExtincao, bool excluir)
        {
            CursoId = cursoId;
            DataExtincao = dataExtincao;
            Excluir = excluir;
        }

        public long CursoId { get; }
        public DateTime DataExtincao { get; }
        public bool Excluir { get; }
    }
}
