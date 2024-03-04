using FluentValidation;
using MediatR;

namespace SME.GoogleClassroom.Aplicacao
{
    public class GerarEmailFuncionarioCommand : IRequest<string>
    {
        public GerarEmailFuncionarioCommand(string nome, string codigoRF, string cpf, bool ehUsuarioParceiro)
        {
            Nome = nome;
            CodigoRF = codigoRF;
            Cpf = cpf;
            EhUsuarioParceiro = ehUsuarioParceiro;
        }

        public string Nome { get; }
        public string CodigoRF { get; }
        public string Cpf { get; }
        public bool EhUsuarioParceiro { get; }
    }

    public class TratarEmailFuncionarioCommandValidator : AbstractValidator<GerarEmailFuncionarioCommand>
    {
        public TratarEmailFuncionarioCommandValidator()
        {
        }
    }
}
