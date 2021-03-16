namespace SME.GoogleClassroom.Infra
{
    public static class RotasRabbit
    {
        public static string ExchangeGoogleSync => "googleclass.exchange";
        public static string FilaGoogleSync => "googleclass.sync.geral";

        #region Cursos
        public static string FilaCursoIncluir => "googleclass.curso.incluir";
        public static string FilaCursoSync => "googleclass.curso.sync";
        public static string FilaCursoErroSync => "googleclass.curso.erro.sync";
        public static string FilaCursoProfessorSync => "googleclass.curso.professor.sync";
        public static string FilaCursoAlunoSync => "googleclass.curso.aluno.sync";
        public static string FilaCursoGradeSync => "googleclass.curso.grade.sync";
        #endregion

        #region Alunos
        public static string FilaAlunoIncluir => "googleclass.aluno.incluir";
        public static string FilaAlunoSync => "googleclass.aluno.sync";
        public static string FilaAlunoCursoSync => "googleclass.aluno.curso.sync";
        public static string FilaAlunoCursoIncluir => "googleclass.aluno.curso.incluir";
        #endregion

        #region Funcionário
        public static string FilaFuncionarioIncluir => "googleclass.funcionario.incluir";
        public static string FilaFuncionarioSync => "googleclass.funcionario.sync";
        #endregion

        #region Professores
        public static string FilaProfessorIncluir => "googleclass.professor.incluir";
        public static string FilaProfessorSync => "googleclass.professor.sync";
        public static string FilaProfessorCursoIncluir => "googleclass.professor.curso.incluir";
        public static string FilaProfessorCursoSync => "googleclass.professor.curso.sync";
        public static string FilaProfessorCursoAtribuicaoSync => "googleclass.professor.curso.atribuicao.sync";
        #endregion
    }
}

