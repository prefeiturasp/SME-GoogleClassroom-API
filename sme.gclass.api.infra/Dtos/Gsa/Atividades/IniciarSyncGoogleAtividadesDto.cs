namespace SME.GoogleClassroom.Infra
{
    public class IniciarSyncGoogleAtividadesDto
    {
        public IniciarSyncGoogleAtividadesDto()
        {
        }

        public IniciarSyncGoogleAtividadesDto(long? cursoId = null, int? pagina = null, int? totalPaginas = null)
        {
            CursoId = cursoId;
            Pagina = pagina;
            TotalPaginas = totalPaginas;
        }

        public long? CursoId { get; set; }
        public int? Pagina { get; set; }
        public int? TotalPaginas { get; set; }
    }

    public class IniciarSyncAtividadesDto : IniciarSyncGoogleAtividadesDto
    {
        public IniciarSyncAtividadesDto()
        {
        }

        public IniciarSyncAtividadesDto(long? cursoId = null, int? pagina = null, int? totalPaginas = null)
            : base(cursoId, pagina, totalPaginas)
        {
        }
    }
}
