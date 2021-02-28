namespace SME.GoogleClassroom.Dominio
{
    public class Professor
    {
        public Professor(long rf, string nome)
        {
            Rf = rf;
            Nome = nome;
        }

        public long Rf { get; set; }
        public string Nome { get; set; }
        public string Email
        {
            get
            {
                if (!string.IsNullOrEmpty(Nome) && Rf > 0)
                {
                    string[] splitNome = Nome.Split(' ');
                    string primeiroNome = splitNome[0];
                    string ultimoNome = "";

                    if (splitNome.Length > 1)
                    {
                        ultimoNome = splitNome[^1];
                    }

                    return $"{primeiroNome}{ultimoNome}.{Rf}@edu.sme.prefeitura.sp.gov.br".ToLower();
                }
                return string.Empty;
            }
        }
    }
}
