using System;

namespace SME.GoogleClassroom.Infra
{
    public class AlunoDto
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Email
        {
            get
            {
                if (!string.IsNullOrEmpty(Nome) && DataNascimento != null)
                {
                    string[] splitNome = Nome.Split(' ');
                    string primeiroNome = splitNome[0];
                    string ultimoNome = "", iniciaisMeio = "";

                    if (splitNome.Length > 1)
                    {
                        ultimoNome = splitNome[^1];

                        if (splitNome.Length > 2)
                        {
                            for (int i = 1; i < splitNome.Length - 1; i++)
                            {
                                iniciaisMeio += splitNome[i].Substring(0, 1);
                            }
                        }
                    }

                    return $"{primeiroNome}{iniciaisMeio}{ultimoNome}.{DataNascimento:ddMMyyyy}@edu.sme.prefeitura.sp.gov.br".ToLower();
                }

                return string.Empty;

            }
        }
    }
}
