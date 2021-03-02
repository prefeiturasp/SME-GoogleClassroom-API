namespace SME.GoogleClassroom.Infra
{
    public static class StringExtensions
    {
        public static string RemoverAcentosECaracteresEspeciais(this string str)
        {
            var strResultado = str;
            string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcento = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            for (int i = 0; i < acentos.Length; i++)
            {
                strResultado = strResultado.Replace(acentos[i], semAcento[i]);
            }

            string[] caracteresEspeciais = { "\\.", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°" };

            for (int i = 0; i < caracteresEspeciais.Length; i++)
            {
                strResultado = strResultado.Replace(caracteresEspeciais[i], "");
            }

            strResultado = strResultado.Replace("^\\s+", "");
            strResultado = strResultado.Replace("\\s+$", "");
            strResultado = strResultado.Replace("\\s+", " ");
            return strResultado;
        }
    }
}