using Nest;
using SME.Pedagogico.Interface.DTO;
using System;

namespace SME.GoogleClassroom.Infra.Dtos.ElasticSearch.AlunoTurma
{
    [ElasticsearchType(RelationName = "alunonaturma")]
    public class AlunoNaTurmaDTO : DocumentoElasticTurma
    {
        [Number(Name = "codigoaluno")]
        public int CodigoAluno { get; set; }
        [Text(Name = "nomealuno")]
        public string NomeAluno { get; set; }
        [Date(Name = "datanascimento", Format = "MMddyyyy")]
        public DateTime DataNascimento { get; set; }
        //[Text(Name = "nomesocialaluno")]
        public string NomeSocialAluno { get; set; }
        //[Number(Name = "codigosituacaomatricula")]
        public int CodigoSituacaoMatricula { get; set; }
        //[Text(Name = "situacaomatricula")]
        public string SituacaoMatricula { get; set; }
        //[Date(Name = "datasituacao", Format = "MMddyyyy")]
        public DateTime DataSituacao { get; set; }
        //[Date(Name = "datamatricula", Format = "MMddyyyy")]
        public DateTime DataMatricula { get; set; }
        //[Text(Name = "numeroalunochamada")]
        public string NumeroAlunoChamada { get; set; }
        //[Number(Name="possuideficiencia")]
        public int PossuiDeficiencia { get; set; }
        //[Text(Name = "nomeresponsavel")]
        public string NomeResponsavel { get; set; }
        //[Number(Name = "tiporesponsavel")]
        public int? TipoResponsavel { get; set; }
        //[Text(Name = "celularresponsavel")]
        public string CelularResponsavel { get; set; }
        //[Date(Name = "dataatualizacaocontato", Format = "MMddyyyy")]
        public DateTime? DataAtualizacaoContato { get; set; }
        //[Number(Name = "codigomatricula")]
        public long CodigoMatricula { get; set; }
        //[Number(Name = "sequencia")]
        public int Sequencia { get; set; }
    }
}
