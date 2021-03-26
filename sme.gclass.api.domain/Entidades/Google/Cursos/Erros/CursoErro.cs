using System;

namespace SME.GoogleClassroom.Dominio
{
    public class CursoErro
    {
        public CursoErro()
        {

        }
        public CursoErro(long turmaId, long componenteCurricularId, string mensagem, ExecucaoTipo execucaoTipo, long? cursoId, ErroTipo tipo)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            Mensagem = mensagem;
            ExecucaoTipo = execucaoTipo;
            CursoId = cursoId;
            DataInclusao = DateTime.Now;
            Tipo = tipo;
        }

        public CursoErro(long turmaId, long componenteCurricularId, string mensagem, ExecucaoTipo execucaoTipo, long? cursoId, DateTime dataInclusao)
        {
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            Mensagem = mensagem;
            ExecucaoTipo = execucaoTipo;
            CursoId = cursoId;
            DataInclusao = dataInclusao;
        }

        public long Id { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public string Mensagem { get; set; }
        public ExecucaoTipo ExecucaoTipo { get; set; }
        public long? CursoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public ErroTipo Tipo { get; set; }
    }
}
