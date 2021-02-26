namespace SME.GoogleClassroom.Infra.Dtos.Funcionarios
{
    public class FuncionarioParaInclusaoDto
    {
        public string CdRegistroFuncional { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string OrganizationPath { get; set; }
        public int CdCargo { get; set; }
    }
}