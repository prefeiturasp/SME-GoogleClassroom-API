using System;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Infra
{
    public struct EscolaResumidaDTO
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string SiglaTipoEscola { get; set; }

        public string NomeEscola => Nome.EstaPreenchido() ? $"{SiglaTipoEscola}-{Nome}" : string.Empty;
        public string DreCodigo { get; set; }
        public string DreSigla { get; set; }
    }
}
