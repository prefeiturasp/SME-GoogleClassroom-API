namespace SME.GoogleClassroom.Infra
{
    public static class RotasRabbit
    {
        public static string FilaGoogleSync => "googleclass.sync.geral";

        #region Cursos
        public static string FilaCursoIncluir => "googleclass.curso.incluir";
        public static string FilaCursoSync => "googleclass.curso.sync";
        public static string FilaCursoErroSync => "googleclass.curso.erro.sync";
        public static string FilaCursoErroTratar => "googleclass.curso.erro.tratar";
        public static string FilaCursoProfessorSync => "googleclass.curso.professor.sync";
        public static string FilaCursoAlunoSync => "googleclass.curso.aluno.sync";
        public static string FilaCursoGradeSync => "googleclass.curso.grade.sync";
        public static string FilaCursoFuncionarioSync => "googleclass.curso.funcionario.sync";
        #endregion

        #region Alunos
        public static string FilaAlunoIncluir => "googleclass.aluno.incluir";
        public static string FilaAlunoSync => "googleclass.aluno.sync";
        public static string FilaAlunoCursoSync => "googleclass.aluno.curso.sync";
        public static string FilaAlunoCursoIncluir => "googleclass.aluno.curso.incluir";
        public static string FilaAlunoErroSync => "googleclass.aluno.erro.sync";
        public static string FilaAlunoErroTratar => "googleclass.aluno.erro.tratar";
        #endregion

        #region Funcionário
        public static string FilaFuncionarioIncluir => "googleclass.funcionario.incluir";
        public static string FilaFuncionarioSync => "googleclass.funcionario.sync";
        public static string FilaFuncionarioCursoIncluir => "googleclass.funcionario.curso.incluir";
        public static string FilaFuncionarioCursoSync => "googleclass.funcionario.curso.sync";
        public static string FilaFuncionarioErroSync => "googleclass.funcionario.erro.sync";
        public static string FilaFuncionarioErroTratar => "googleclass.funcionario.erro.tratar";
        #endregion

        #region Professores
        public static string FilaProfessorIncluir => "googleclass.professor.incluir";
        public static string FilaProfessorSync => "googleclass.professor.sync";
        public static string FilaProfessorCursoIncluir => "googleclass.professor.curso.incluir";
        public static string FilaProfessorCursoSync => "googleclass.professor.curso.sync";
        public static string FilaProfessorCursoAtribuicaoSync => "googleclass.professor.curso.atribuicao.sync";
        public static string FilaProfessorCursoRemover => "googleclass.professor.curso.remover";
        public static string FilaProfessorErroSync => "googleclass.professor.erro.sync";
        public static string FilaProfessorErroTratar => "googleclass.professor.erro.tratar";
        #endregion

        #region Funcionário indireto
        public static string FilaFuncionarioIndiretoSync => "googleclass.funcionario.indireto.sync";
        public static string FilaFuncionarioIndiretoIncluir => "googleclass.funcionario.indireto.incluir";
        #endregion

        #region Usuários
        public static string FilaUsuarioGoogleIdSync => "googleclass.usuario.googleid.sync";
        public static string FilaUsuarioGoogleIdAtualizar => "googleclass.usuario.googleid.atualizar";
        #endregion

        #region GSA
        public static string FilaGsaGoogleSync => "googleclass.gsa.sync";
        public static string FilaGsaCursoCarregar => "googleclass.gsa.curso.carregar";
        public static string FilaGsaCursoIncluir => "googleclass.gsa.curso.incluir";
        public static string FilaGsaCursoValidar => "googleclass.gsa.curso.validar";
        public static string FilaGsaUsuarioCarregar => "googleclass.gsa.usuario.carregar";
        public static string FilaGsaUsuarioValidar => "googleclass.gsa.usuario.validar";
        public static string FilaGsaUsuarioIncluir => "googleclass.gsa.usuario.incluir";
        public static string FilaGsaCursoUsuarioCarregar => "googleclass.gsa.curso.usuario.carregar";
        public static string FilaGsaCursoUsuarioIncluir => "googleclass.gsa.curso.usuario.incluir";
        public static string FilaGsaMuralAvisosCarregar => "googleclass.gsa.mural.avisos.carregar";
        public static string FilaGsaMuralAvisosTratar => "googleclass.gsa.mural.avisos.tratar";
        public static string FilaGsaMuralAvisosIncluir => "googleclass.gsa.mural.avisos.incluir";
        public static string FilaGsaMuralAvisosIncluirErro => "googleclass.gsa.mural.avisos.incluir.erro";
        #endregion

        #region Usuários Remover
        public static string FilaGsaCursoUsuarioRemovidoTurmasCarregar => "googleclass.gsa.curso.usuario.removido.turmas.carregar";
        public static string FilaGsaCursoUsuarioRemovidoTurmaTratar => "googleclass.gsa.curso.usuario.removido.turma.tratar";
        public static string FilaGsaCursoUsuarioRemovidoAlunosTratar => "googleclass.gsa.curso.usuario.removido.alunos.tratar";
        public static string FilaGsaCursoUsuarioRemovidoSync => "googleclass.gsa.curso.usuario.removido.sync";

        public static string FilaGsaCursoUsuarioRemovidoProfessoresTratarErro => "googleclass.gsa.curso.usuario.removido.professores.tratar.erro";
        #endregion
    }
}
