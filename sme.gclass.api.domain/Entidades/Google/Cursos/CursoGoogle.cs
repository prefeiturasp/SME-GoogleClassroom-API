using System;

namespace SME.GoogleClassroom.Dominio
{
    public class CursoGoogle
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public string Email { get; set; }
        public TurmaTipo TurmaTipo { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool ExisteGoogle { get; set; }

        public CursoGoogle(string nome, string secao, long turmaId, long componenteCurricularId, string email)
        {
            Nome = nome;
            Secao = secao;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            Email = email;
            DataInclusao = DateTime.Now;
            ExisteGoogle = true;
        }

        public CursoGoogle(string nome, string secao, long turmaId, long componenteCurricularId, string email, TurmaTipo turmaTipo)
        {
            Nome = nome;
            Secao = secao;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            Email = email;
            DataInclusao = DateTime.Now;
            TurmaTipo = turmaTipo;
            ExisteGoogle = true;
        }

        protected CursoGoogle()
        {
        }
    }
}