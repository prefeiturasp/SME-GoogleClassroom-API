using System;

namespace SME.GoogleClassroom.Dominio
{
    public class AlunoCursoEol
    {
        public long CodigoAluno { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public long CursoId { get; set; }
        public string UeCodigo { get; set; }
        public string MensagemErro { get; set; }
        public string NomePessoa { get; set; }
        public string NomeSocial { get; set; }
        public string OrganizationPath { get; set; }
        public long CodigoRF { get; set; }
        public DateTime DataNascimento { get; set; }

        public AlunoCursoEol(long codigoAluno, long turmaId, long componenteCurricularId)
        {
            CodigoAluno = codigoAluno;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
        }

        public AlunoCursoEol(long codigoRf, long cursoId, string nomePessoa, string nomeSocial, string organizationPath)
        {
            CodigoRF = codigoRf;
            CursoId = cursoId;
            NomePessoa = nomePessoa;
            NomeSocial = nomeSocial;
            OrganizationPath = organizationPath;
        }

        public AlunoCursoEol(long codigoAluno, long cursoId)
        {
            CodigoAluno = codigoAluno;
            CursoId = cursoId;
        }
        
        public AlunoCursoEol(long codigoAluno, long turmaId, long componenteCurricularId, string nomeSocial, string nomePessoa, DateTime dataNascimento)
        {
            CodigoAluno = codigoAluno;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            NomeSocial = nomeSocial;
            NomePessoa = NomePessoa;
            DataNascimento = dataNascimento;
        }

        protected AlunoCursoEol()
        {
        }
    }
}