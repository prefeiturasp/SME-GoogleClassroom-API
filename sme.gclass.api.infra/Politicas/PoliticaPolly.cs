using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra.Politicas
{
    public abstract class PoliticaPolly
    {
        public static string GoogleSync => "RetryPolicy";
    }
}
