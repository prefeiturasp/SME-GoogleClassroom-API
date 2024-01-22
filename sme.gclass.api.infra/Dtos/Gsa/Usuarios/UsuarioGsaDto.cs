using System;
using SME.GoogleClassroom.Dominio;

namespace SME.GoogleClassroom.Infra
{
    public class UsuarioGsaDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        public bool EhAdmin { get; set; }
        public string OrganizationPath { get; set; }
        public DateTime? DataInclusao { get; set; }
        public bool UltimoItemDaFila { get; set; }
        public long Indice { get; set; } //de 'usuario'
        public string MensagemErro { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
    }
}