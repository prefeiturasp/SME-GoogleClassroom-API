namespace SME.GoogleClassroom.Dominio
{
    public class CursoArquivarErro
    {
        public long CursoId { get; set; }
        public bool Extinto { get; set; }

        public CursoArquivarErro(long cursoId, bool extinto)
        {
            CursoId = cursoId;
            Extinto = extinto;
        }

        public CursoArquivarErro()
        {
        }
    }
}