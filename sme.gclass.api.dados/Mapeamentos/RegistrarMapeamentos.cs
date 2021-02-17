using Dapper.FluentMap;

namespace SME.GoogleClassroom.Dados
{
    public static class RegistrarMapeamentos
    {
        public static void Registrar()
        {
            FluentMapper.Initialize(config =>
            {
            });
        }
    }
}
