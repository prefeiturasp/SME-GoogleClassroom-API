﻿using System;

namespace SME.GoogleClassroom.Infra
{
    public class CursoGsaDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public string CriadorId { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInclusao { get; set; }
        public bool UltimoItemDaFila { get; set; }
        public bool ExecutarCargaDeUsuariosGsa { get; set; }
    }
}