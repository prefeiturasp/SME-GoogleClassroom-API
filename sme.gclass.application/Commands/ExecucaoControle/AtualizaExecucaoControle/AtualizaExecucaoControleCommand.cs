﻿using MediatR;
using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AtualizaExecucaoControleCommand : IRequest<bool>
    {
        public AtualizaExecucaoControleCommand(ExecucaoTipo execucaoTipo, DateTime data)
        {
            ExecucaoTipo = execucaoTipo;
            Data = data;
        }

        public ExecucaoTipo ExecucaoTipo { get; set; }
        public DateTime Data { get; set; }
    }
}