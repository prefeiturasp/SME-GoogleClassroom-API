using MediatR;
using SME.GoogleClassroom.Dados;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.GoogleClassroom.Aplicacao.Commands.Cursos.AlterarCurso
{
    public class AlterarCursoCommandHandler : IRequestHandler<AlterarCursoCommand, bool>
    {
        private readonly IRepositorioCurso repositorio;

        public AlterarCursoCommandHandler(IRepositorioCurso repositorio)
        {
            this.repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        public async Task<bool> Handle(AlterarCursoCommand request, CancellationToken cancellationToken)
        {
            var id = request.Curso.Id;
            var email = request.Curso.Email;
            var nome = request.Curso.Nome;
            var secao = request.Curso.Secao;
            var turmaId = request.Curso.TurmaId;
            var componenteCurricularId = request.Curso.ComponenteCurricularId;
            var dataInclusao = request.Curso.DataInclusao;
            var dataAtualizacao = request.Curso.DataAtualizacao;
            return await repositorio.AlterarAsync(id, email, nome, secao, turmaId, componenteCurricularId, dataInclusao, dataAtualizacao);
        }
    }
}
