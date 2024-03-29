﻿namespace SME.GoogleClassroom.Infra
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
        public static string FilaCursoExtintoArquivarCarregar => "googleclass.gsa.curso.extinto.arquivar.carregar";
        public static string FilaCursoArquivarAnoAnteriorCarregar => "googleclass.gsa.curso.arquivar.iniciar";
        public static string FilaCursoArquivarCarregar => "googleclass.gsa.curso.arquivar.carregar";
        public static string FilaCursoArquivarTratar => "googleclass.gsa.curso.arquivar.tratar";
        public static string FilaCursoArquivarSync => "googleclass.gsa.curso.arquivar.sync";
        public static string FilaCursoArquivarTratarErro => "googleclass.gsa.curso.arquivar.tratar.erro";
        public static string FilaCursoArquivarSyncErro => "googleclass.gsa.curso.arquivar.sync.erro";

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
        public static string FilaUsuarioGoogleTratarErro => "googleclass.usuario.erro.tratar";
        #endregion

        #region GSA
        public static string FilaGsaGoogleSync => "googleclass.gsa.sync";
        public static string FilaGsaCursoCarregar => "googleclass.gsa.curso.carregar";
        public static string FilaGsaCursoIncluir => "googleclass.gsa.curso.incluir";
        public static string FilaGsaCursoValidar => "googleclass.gsa.curso.validar";
        public static string FilaGsaUsuarioCarregar => "googleclass.gsa.usuario.carregar";
        public static string FilaGsaUsuarioCarregarErro => "googleclass.gsa.usuario.carregar.erro";
        public static string FilaGsaUsuarioValidar => "googleclass.gsa.usuario.validar";
        public static string FilaGsaUsuarioIncluir => "googleclass.gsa.usuario.incluir";
        public static string FilaGsaUsuarioIncluirErro => "googleclass.gsa.usuario.incluir.erro";
        public static string FilaGsaCursoUsuarioCarregar => "googleclass.gsa.curso.usuario.carregar";
        public static string FilaGsaCursoUsuarioIncluir => "googleclass.gsa.curso.usuario.incluir";
        public static string FilaGsaMuralAvisosCarregar => "googleclass.gsa.mural.avisos.carregar";
        public static string FilaGsaMuralAvisosTratar => "googleclass.gsa.mural.avisos.tratar";
        public static string FilaGsaMuralAvisosIncluir => "googleclass.gsa.mural.avisos.incluir";
        public static string FilaGsaMuralAvisosIncluirErro => "googleclass.gsa.mural.avisos.incluir.erro";
        public static string FilaGsaAtividadesCarregar => "googleclass.gsa.atividades.carregar";
        public static string FilaGsaAtividadesTratar => "googleclass.gsa.atividades.tratar";
        public static string FilaGsaAtividadesIncluir => "googleclass.gsa.atividades.incluir";
        public static string FilaGsaAtividadesIncluirErro => "googleclass.gsa.atividades.incluir.erro";

        //Notas
        public static string FilaGsaNotasAtividadesCarregar => "googleclass.gsa.notas.atividades.carregar";
        public static string FilaGsaNotasAtividadesTratar => "googleclass.gsa.notas.atividades.tratar";
        public static string FilaGsaNotasAtividadesSync => "googleclass.gsa.notas.atividades.sync";
        public static string FilaGsaNotasAtividadesSyncErro => "googleclass.gsa.notas.atividades.sync.erro";
        
        //Celp
        public static string FilaGsaCursosCelpSync => "googleclass.gsa.cursos.celp.sync";
        public static string FilaGsaCursoCelpIncluir => "googleclass.gsa.curso.celp.incluir";
        public static string FilaGsaCursosAlunosCelpSync => "googleclass.gsa.cursos.alunos.celp.sync";
        public static string FilaGsaFuncionarioCursoCelpIncluir => "googleclass.gsa.funcionario.curso.celp.incluir";
        public static string FilaGsaAlunoCelpIncluir => "googleclass.gsa.aluno.celp.incluir";
        public static string FilaGsaCursoAlunoCelpIncluir => "googleclass.gsa.curso.aluno.celp.incluir";
        

        //Carga inicial
        public static string FilaGsaCargaInicial => "googleclass.gsa.carga.inicial.sync";
        #endregion

        #region CursoRemover

        public static string FilaCursoAhRemover => "googleclass.gsa.curso.remover.sync";

        #endregion
        
        #region Inativação de Usuários
        public static string FilaGsaInativarUsuarioIniciar => "googleclass.gsa.inativar.usuario.iniciar";
        public static string FilaGsaInativarUsuarioCarregar => "googleclass.gsa.inativar.usuario.carregar";
        public static string FilaGsaInativarUsuarioSync => "googleclass.gsa.inativar.usuario.sync";
        public static string FilaGsaInativarUsuarioIncluir => "googleclass.gsa.inativar.usuario.incluir";

        #endregion

        #region Inativação de Professores
        public static string FilaInativarProfessoresEFuncionariosIniciar => "googleclass.gsa.inativar.professor.iniciar";
        public static string FilaCarregarProfessoresEFuncionariosInativar => "googleclass.gsa.inativar.professor.carregar";
        public static string FilaGsaInativarProfessorSync => "googleclass.gsa.inativar.professor.sync";
        public static string FilaTratarProfessoresEFuncionariosInativar => "googleclass.gsa.inativar.professor.tratar";
        public static string FilaInativarProfessoresEFuncionariosInativarSync => "googleclass.gsa.inativar.professor.incluir";
        public static string FilaInativarProfessorErroTratar => "googleclass.gsa.inativar.professor.erro.tratar";

        #endregion 

        #region Formação Cidade
        public static string FilaGsaFormacaoCidadeTurmasTratarSmeDre => "googleclass.gsa.formacao.cidade.turmas.tratar.sme.dre";        
        public static string FilaGsaFormacaoCidadeTurmasTratarSmeDreErro => "googleclass.gsa.formacao.cidade.turmas.tratar.sme.dre.erro";
        public static string FilaGsaFormacaoCidadeTurmasTratarComponente => "googleclass.gsa.formacao.cidade.turmas.tratar.componente";
        public static string FilaGsaFormacaoCidadeTurmasTratarComponenteErro => "googleclass.gsa.formacao.cidade.turmas.tratar.componente.erro";
        public static string FilaGsaFormacaoCidadeTurmasTratarCurso => "googleclass.gsa.formacao.cidade.turmas.tratar.curso";
        public static string FilaGsaFormacaoCidadeTurmasTratarCursoErro => "googleclass.gsa.formacao.cidade.turmas.tratar.curso.erro";
        public static string FilaGsaFormacaoCidadeTurmasTratarAluno => "googleclass.gsa.formacao.cidade.turmas.tratar.aluno";
        public static string FilaGsaFormacaoCidadeTurmasTratarAlunoErro => "googleclass.gsa.formacao.cidade.turmas.tratar.aluno.erro";
        #endregion

        #region Usuários Remover

        public static string FilaGsaCursoUsuarioRemovidoTurmasCarregar      => "googleclass.gsa.curso.usuario.removido.turmas.carregar";
        public static string FilaGsaCursoUsuarioRemovidoTurmaTratar         => "googleclass.gsa.curso.usuario.removido.turma.tratar";
        public static string FilaGsaCursoUsuarioRemovidoAlunosTratar        => "googleclass.gsa.curso.usuario.removido.alunos.tratar";
        public static string FilaGsaCursoUsuarioRemovidoAlunosCelpTratar        => "googleclass.gsa.curso.usuario.removido.alunos.celp.tratar";
        public static string FilaGsaCursoUsuarioRemovidoProfessoresTratar   => "googleclass.gsa.curso.usuario.removido.professor.tratar";
        public static string FilaGsaCursoUsuarioRemovidoFuncionarioTratar   => "googleclass.gsa.curso.usuario.removido.funcionario.tratar";
        public static string FilaGsaCursoUsuarioRemovidoSync                => "googleclass.gsa.curso.usuario.removido.sync";
        
        public static string FilaGsaCursoUsuarioRemovidoProfessoresTratarErro => "googleclass.gsa.curso.usuario.removido.professor.tratar.erro";
        public static string FilaGsaCursoUsuarioRemovidoFuncionarioTratarErro => "googleclass.gsa.curso.usuario.removido.funcionario.tratar.erro";
        public static string FilaGsaCursoUsuarioRemovidoErroTratar            => "googleclass.gsa.curso.usuario.removido.erro.tratar";

        #endregion
    }
}
