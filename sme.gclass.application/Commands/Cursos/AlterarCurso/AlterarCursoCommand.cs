using MediatR;
using SME.GoogleClassroom.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class AlterarCursoCommand :  IRequest<bool>
    {
        public AlterarCursoCommand(CursoGoogle curso)
        {
            Curso = curso;
        }

        public CursoGoogle Curso { get; set; }
    }
}
