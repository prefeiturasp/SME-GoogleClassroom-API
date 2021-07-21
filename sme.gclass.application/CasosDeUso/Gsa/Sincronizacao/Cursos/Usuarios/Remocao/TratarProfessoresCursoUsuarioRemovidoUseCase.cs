using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TratarProfessoresCursoUsuarioRemovidoUseCase : ITratarProfessoresCursoUsuarioRemovidoUseCase
    {
        private readonly IMediator mediator;

        public TratarProfessoresCursoUsuarioRemovidoUseCase()
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task Executar(MensagemRabbit mensagemRabbit)
        {
            var dto = mensagemRabbit.ObterObjetoMensagem<FiltroTurmaRemoverCursoUsuarioDto>();

            // Query com usuarios a remover
            // Com TurmaCodigo e ComponenteCurricularCodigo deve se localizar o curso

            var professoresASeremRemovidos = new List<RemoverAtribuicaoProfessorCursoEolDto>();
            CursoUsuarioRemoverDto cursoUsuarioRemover;

            foreach (var professorASerRemovido in professoresASeremRemovidos)
            {
                var professorCurso = await PequeInformacoesDoProfessorECurso(professorASerRemovido);

                cursoUsuarioRemover = new CursoUsuarioRemoverDto
                {
                    CursoId = professorCurso.curso.CursoId,
                    TipoUsuario = (int)UsuarioTipo.Professor,
                    TipoGsa = (int)UsuarioCursoGsaTipo.Professor,
                };

                //UsuarioId = cursoUsuario.UsuarioId,
                //UsuarioGsaId = cursoUsuario.UsuarioGsaId,

                if (ProfessorASerRemovidoEhResponsavelPeloCurso(professorCurso.professor, professorCurso.curso))
                {
                    var funcionariosDoCurso = await mediator.Send(new ObterFuncionariosPorCursoQuery(professorCurso.curso.CursoId));

                    var novoResponsavel = DefinaNovoResponsavelPeloCurso(funcionariosDoCurso, professorCurso.professor);

                    // AtribuirDonoCursoUseCase
                    //var donoDoCursoAlterado = await mediator.Send(new AtribuirDonoCursoGoogleCommand(novoResponsavel.Email, professorASerRemovido.TurmaCodigo, professorASerRemovido.ComponenteCurricularCodigo));
                }

                await mediator.Send(new PublicaFilaRabbitCommand(RotasRabbit.FilaGsaCursoUsuarioRemovidoSync, cursoUsuarioRemover));
            }
        }

        private UsuarioGoogle DefinaNovoResponsavelPeloCurso(IEnumerable<UsuarioGoogle> funcionariosDoCurso, ProfessorCursosCadastradosDto professor)
        {
            //Refatorar
            var funcionarios = funcionariosDoCurso.Where(o => !o.Email.Equals(professor.Email)).ToList();
            var funcionarioResponsavel = funcionarios.FirstOrDefault(o => o.OrganizationPath.Equals("/Professores"));

            if (funcionarioResponsavel != null)
                return funcionarioResponsavel;

            funcionarioResponsavel = funcionarios.FirstOrDefault(o => o.OrganizationPath.Equals("/Admin/CP"));

            if (funcionarioResponsavel != null)
                return funcionarioResponsavel;

            funcionarioResponsavel = funcionarios.FirstOrDefault(o => o.OrganizationPath.Equals("/Admin/AD"));

            if (funcionarioResponsavel != null)
                return funcionarioResponsavel;

            funcionarioResponsavel = funcionarios.FirstOrDefault(o => o.OrganizationPath.Equals("/Admin/DIRETOR"));

            if (funcionarioResponsavel != null)
                return funcionarioResponsavel;

            return null;
        }

        private async Task<(ProfessorCursosCadastradosDto professor, CursoDto curso)> PequeInformacoesDoProfessorECurso(RemoverAtribuicaoProfessorCursoEolDto professorASerRemovido)
        {
            var professorCurso = await mediator.Send(new ObterProfessoresCursosGoogleQuery(new Paginacao(0, 1), null, professorASerRemovido.TurmaCodigo, professorASerRemovido.ComponenteCurricularCodigo));
            
            //Tratar caso não exista resultado
            var professor = professorCurso.Items.FirstOrDefault();
            var curso = professor.Cursos.FirstOrDefault();

            return (professor, curso);
        }

        private bool ProfessorASerRemovidoEhResponsavelPeloCurso(ProfessorCursosCadastradosDto professor, CursoDto curso)
        {
            return curso.Email.Equals(professor.Email);
        }
    }
}
