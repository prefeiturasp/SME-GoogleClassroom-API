﻿using SME.GoogleClassroom.Dominio;
using System;

namespace SME.GoogleClassroom.Infra
{
    public class RetornoNotasSgpDto
    {
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long AtividadeGoogleClassroomId { get; set; }
        public StatusGSA StatusGsa { get; set; }
        public double Nota { get; set; }
        public DateTime? DataEntregaAvaliacao { get; set; }
        public long CodigoAluno { get; set; }
        public string Registro { get; set; }

        public RetornoNotasSgpDto(long turmaId, long componenteCurricularId, long atividadeGoogleClassroomId,
            StatusGSA statusGsa, double nota, DateTime? dataEntregaAvaliacao, long codigoAluno, string registro)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            AtividadeGoogleClassroomId = atividadeGoogleClassroomId;
            StatusGsa = statusGsa;
            Nota = nota;
            DataEntregaAvaliacao = dataEntregaAvaliacao;
            CodigoAluno = codigoAluno;
            Registro = registro;
        }
    }
}