﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public class CursoComparativoDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public string CriadorId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}