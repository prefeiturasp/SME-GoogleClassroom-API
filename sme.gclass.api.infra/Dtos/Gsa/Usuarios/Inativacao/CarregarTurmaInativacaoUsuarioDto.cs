using System;

namespace SME.GoogleClassroom.Infra
{
    public class CarregarTurmaInativacaoUsuarioDto
    {
        public CarregarTurmaInativacaoUsuarioDto()
        {
        }

        public CarregarTurmaInativacaoUsuarioDto(int anoLetivo, DateTime dataReferencia, int pagina, int totalRegistros)
        {
            AnoLetivo = anoLetivo;
            DataReferencia = dataReferencia;
            Pagina = pagina;
            TotalRegistros = totalRegistros;
        }

        public int AnoLetivo { get; set; }
        public DateTime DataReferencia { get; set; }
        public int Pagina { get; set; }
        public int TotalRegistros { get; set; }
    }
}
