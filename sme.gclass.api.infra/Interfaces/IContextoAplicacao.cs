using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public interface IContextoAplicacao
    {
        IDictionary<string, object> Variaveis { get; set; }

        string UsuarioLogado { get; }
        string NomeUsuario { get; }

        T ObterVarivel<T>(string nome);

        IContextoAplicacao AtribuirContexto(IContextoAplicacao contexto);
        void AdicionarVariaveis(IDictionary<string, object> variaveis);
    }
}
