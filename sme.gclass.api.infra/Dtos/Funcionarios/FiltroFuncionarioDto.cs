using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroFuncionarioDto
    {
        public FiltroFuncionarioDto(FuncionarioEol funcionarioEol, ParametrosCargaInicialDto parametrosCargaInicial)
        {
            FuncionarioEol = funcionarioEol;
            ParametrosCargaInicial = parametrosCargaInicial;
        }

        public FuncionarioEol FuncionarioEol { get; set; }
        public ParametrosCargaInicialDto ParametrosCargaInicial { get; set; }
    }
}
