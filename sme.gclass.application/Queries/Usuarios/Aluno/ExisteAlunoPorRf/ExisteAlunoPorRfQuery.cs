using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ExisteAlunoPorRfQuery : IRequest<bool>
    {
        public ExisteAlunoPorRfQuery(long rf)
        {
            Rf = rf;
        }

        public long Rf { get; set; }
    }
}