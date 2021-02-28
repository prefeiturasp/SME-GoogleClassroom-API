using MediatR;
using System;

namespace SME.GoogleClassroom.Aplicacao
{
    public class InserirCursoCommand : IRequest<long>
    {
        public InserirCursoCommand(long id, string email, string nome, string secao, long turmaId, long componenteCurricularId, DateTime dataInclusao, DateTime? dataAtualizacao)
        {
            Id = id;
            Email = email;
            Nome = nome;
            Secao = secao;
            TurmaId = turmaId;
            ComponenteCurricularId = componenteCurricularId;
            DataInclusao = dataInclusao;
            DataAtualizacao = dataAtualizacao;
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Secao { get; set; }
        public long TurmaId { get; set; }
        public long ComponenteCurricularId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

    }
}
