namespace SME.GoogleClassroom.Infra.Politicas
{
    public static class PoliticaPolly
    {
        public static string PolicyGoogleSync => "RetryPolicy";
        public static string PolicyCargaGsa => "RetryGsaPolicy";
        public static string PolicyPublicaFila => "RetryGsaPublicaFila";
    }
}