using System;

namespace SME.GoogleClassroom.Dominio
{
    public class ProfessorGoogle : UsuarioGoogle
    {
        public long Rf { get; set; }

        public ProfessorGoogle(long rf, string nome, string email, string organizationPath)
            :base(nome, email, organizationPath)
        {
            Rf = rf;
        }

        protected ProfessorGoogle()
        {
        }
    }
}