﻿namespace SME.GoogleClassroom.Infra
{
    public class FuncionarioParaIncluirGoogleDto
    {
        public string CdRegistroFuncional { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string OrganizationPath { get; set; }
        public int CdCargo { get; set; }
    }
}