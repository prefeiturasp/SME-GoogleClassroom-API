namespace SME.GoogleClassroom.Infra
{
    public class ConsumoDeFilasOptions
    {
        private ConsumoDeFilasGsa gsa;

        public ConsumoDeFilasOptions()
        {
            gsa = new ConsumoDeFilasGsa();
        }

        public ushort LimiteDeMensagensPorExecucao { get; set; }
        public bool ConsumirFilasSync { get; set; }
        public bool ConsumirFilasDeInclusao { get; set; }
        public ConsumoDeFilasGsa Gsa
        {
            get => gsa ??= new ConsumoDeFilasGsa();
            set => gsa = value ?? new ConsumoDeFilasGsa();
        }
    }

    public class ConsumoDeFilasGsa
    {
        public bool CargaAtividadesGsa { get; set; }
        public bool CargaMuralAvisosGsa { get; set; }
        public bool CargaUsuarioGsa { get; set; }
        public bool ProcessarUsuarioGsa { get; set; }
        public bool CargaCursoGsa { get; set; }
        public bool ProcessarCursoGsa { get; set; }
        public bool CargaCursoUsuarioGsa { get; set; }
        public bool ProcessarCursoUsuarioGsa { get; set; }
    }
}
