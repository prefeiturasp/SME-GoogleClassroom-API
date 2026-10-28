namespace SME.GoogleClassroom.Infra
{
    public class FiltroObterUsuariosRemovidosCursosDto : FiltroPaginacaoBaseDto
    {
        /// <summary>
        /// Identificador do curso no Google Classroom (opcional). Quando informado 0 ou omitido, retorna os professores removidos de todos os cursos.
        /// </summary>
        public long CursoId { get; set; }
    }
}
