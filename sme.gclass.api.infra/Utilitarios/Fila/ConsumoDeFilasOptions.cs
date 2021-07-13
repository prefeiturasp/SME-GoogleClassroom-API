namespace SME.GoogleClassroom.Infra
{
    public class ConsumoDeFilasOptions
    {
        public ushort LimiteDeMensagensPorExecucao { get; set; }
        public bool ConsumirFilasSync { get; set; }
        public bool ConsumirFilasDeInclusao { get; set; }
        public ConsumoDeFilasGsa Gsa { get; set; }
    }

    public class ConsumoDeFilasGsa
    {
        public bool CargaUsuarioGsa { get; set; }
        public bool ProcessarUsuarioGsa { get; set; }
        public bool CargaCursoGsa { get; set; }
        public bool ProcessarCursoGsa { get; set; }
        public bool CargaCursoUsuarioGsa { get; set; }
        public bool ProcessarCursoUsuarioGsa { get; set; }
    }
}