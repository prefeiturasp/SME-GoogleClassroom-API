namespace SME.GoogleClassroom.Infra
{
    public class ConsumoDeFilasOptions
    {
        public ushort LimiteDeMensagensPorExecucao { get; set; }
        public bool ConsumirFilasSync { get; set; }
        public bool ConsumirFilasDeInclusao { get; set; }
        public ConsumeDeFilasGsa Gsa { get; set; }
    }

    public class ConsumeDeFilasGsa
    {
        public bool CargaUsuarioGsa { get; set; }
        public bool ProcessarUsuarioGsa { get; set; }
        public bool CargaCursoGsa { get; set; }
        public bool ProcessarCursoGsa { get; set; }
        public bool CargaUsuarioCursoGsa { get; set; }
        public bool ProcessarUsuarioCursoGsa { get; set; }
    }
}