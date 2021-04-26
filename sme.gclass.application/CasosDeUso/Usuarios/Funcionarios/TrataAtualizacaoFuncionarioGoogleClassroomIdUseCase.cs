using MediatR;
using SME.GoogleClassroom.Aplicacao.Interfaces;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class TrataAtualizacaoFuncionarioGoogleClassroomIdUseCase : TrataAtualizacaoUsuarioGoogleClassroomIdUseCase<FuncionarioGoogle>, ITrataAtualizacaoFuncionarioGoogleClassroomIdUseCase
    {
        public TrataAtualizacaoFuncionarioGoogleClassroomIdUseCase(IMediator mediator)
            : base(mediator)
        {
        }

        protected override UsuarioTipo UsuarioTipo => UsuarioTipo.Funcionario;

        protected override string RotaFilaRabbitSync => RotasRabbit.FilaFuncionarioGoogleIdSync;

        protected override string RotaFilaRabbitAtualizar => RotasRabbit.FilaFuncionarioGoogleIdAtualizar;
    }
}