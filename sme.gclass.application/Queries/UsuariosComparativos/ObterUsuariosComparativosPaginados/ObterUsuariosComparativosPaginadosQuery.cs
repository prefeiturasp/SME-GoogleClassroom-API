using FluentValidation;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterUsuariosComparativosPaginadosQuery : IRequest<PaginacaoResultadoDto<UsuarioComparativo>>
    {
        public ObterUsuariosComparativosPaginadosQuery(Paginacao paginacao, string email, string nome, string organizationPath)
        {
            Paginacao = paginacao;
            Email = email;
            Nome = nome;
            OrganizationPath = organizationPath;
        }

        public Paginacao Paginacao { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string OrganizationPath { get; set; }
    }

    public class ObterUsuariosComparativosPaginadosQueryValidator : AbstractValidator<ObterUsuariosComparativosPaginadosQuery>
    {
        public ObterUsuariosComparativosPaginadosQueryValidator()
        {
            RuleFor(x => x.Paginacao)
                .NotEmpty()
                .WithMessage("A paginação deve ser informada.");

            RuleFor(x => x.Paginacao.QuantidadeRegistros)
                .GreaterThan(0)
                .WithMessage("O número da página e a quantidade de registro devem ser informados.");
        }
    }
}
