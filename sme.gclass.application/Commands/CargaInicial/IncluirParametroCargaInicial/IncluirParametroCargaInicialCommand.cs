using MediatR;
using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Dtos.Gsa.Carga_Inicial;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao.Commands.CargaInicial.IncluirParametroCargaInicial
{
    public class IncluirParametroCargaInicialCommand : IRequest<ParametrosCargaInicialDto>
    {
        public int Ano { get; set; }
        public IList<int> TiposUes { get; set; }
        public IList<long> Ues { get; set; }
        public IList<long> Turmas { get; set; }

        public IncluirParametroCargaInicialCommand(FiltroCargaInicial filtro)
        {
            Ano = filtro.Ano;
            TiposUes = filtro.TiposUes;
            Ues = filtro.Ues;
            Turmas = filtro.Turmas;
        }
    }
}
