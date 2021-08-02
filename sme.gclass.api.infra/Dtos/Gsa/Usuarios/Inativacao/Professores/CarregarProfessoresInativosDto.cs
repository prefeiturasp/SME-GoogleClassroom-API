using System;

namespace SME.GoogleClassroom.Infra
{
    public class CarregarProfessoresInativosDto
    {
        public DateTime DataReferencia { get; set; }
        public string Rf { get; set; }

        public CarregarProfessoresInativosDto(DateTime dataReferencia, string rf)
        {
            DataReferencia = dataReferencia;
            Rf = rf;
        }
    }
}
