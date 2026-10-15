namespace SME.GoogleClassroom.Infra.Dtos.Gsa.Atividades
{
    /// <summary>
    /// Filtros opcionais para iniciar a carga de atividades do Google Sala de Aula.
    /// Envie <c>{}</c> para carregar as atividades de todos os cursos.
    /// </summary>
    public class IniciarSyncAtividadesDto
    {
        /// <summary>Id do curso no Google Sala de Aula. Nulo = todos os cursos.</summary>
        public long? CursoId { get; set; }

        /// <summary>Página inicial da carga. Nulo = começa da primeira.</summary>
        public int? Pagina { get; set; }

        /// <summary>Total de páginas a processar. Nulo = todas.</summary>
        public int? TotalPaginas { get; set; }
    }
}
