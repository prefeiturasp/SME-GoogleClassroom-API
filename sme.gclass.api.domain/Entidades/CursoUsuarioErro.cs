using System;

namespace SME.GoogleClassroom.Dominio
{
    public class CursoUsuarioErro
    {
        public long Id { get; set; }
        public long? Rf { get; set; }
        public long? TurmaId { get; set; }
        public long? ComponenteCurricularId { get; set; }
        public ExecucaoTipo ExecucaoTipo { get; set; }
        public ErroTipo Tipo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataInclusao { get; set; }

        public CursoUsuarioErro(long? rf, long? turmaId, long? componenteCurricularId, ExecucaoTipo execucaoTipo, ErroTipo tipo, string mensagem)
        {
            Rf = rf;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            ExecucaoTipo = execucaoTipo;
            Tipo = tipo;
            Mensagem = mensagem;
            DataInclusao = DateTime.Now;
        }
    }
}