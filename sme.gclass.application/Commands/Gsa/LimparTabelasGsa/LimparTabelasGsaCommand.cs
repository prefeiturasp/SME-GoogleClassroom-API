﻿using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class LimparTabelasGsaCommand : IRequest
    {
        public bool CursosGsa { get; set; }
        public bool UsuariosGsa { get; set; }
        public bool UsuariosInativosGsa { get; set; }
    }
}