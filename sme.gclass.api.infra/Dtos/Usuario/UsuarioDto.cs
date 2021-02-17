using System;
using System.Text.RegularExpressions;

namespace SME.GoogleClassroom.Infra
{
    public class UsuarioDto
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string CodigoRf { get; set; }
        public string Email { get; set; }
        public bool EmailValido => !string.IsNullOrWhiteSpace(Email) &&
                Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
    }
}
