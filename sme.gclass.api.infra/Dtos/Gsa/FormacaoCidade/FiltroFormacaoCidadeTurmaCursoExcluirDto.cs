using System;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Infra
{
    public class FiltroFormacaoCidadeTurmaCursoExcluirDto
    {
        public List<Cours> courses { get; set; }
    }

    public class TeacherFolder
    {
        public string id { get; set; }
    }

    public class GradebookSettings
    {
        public string calculationType { get; set; }
        public string displaySetting { get; set; }
    }

    public class Cours
    {
        public long id { get; set; }
        public string name { get; set; }
        public string section { get; set; }
        public long ownerId { get; set; }
        public DateTime? creationTime { get; set; }
        public DateTime? updateTime { get; set; }
        public string enrollmentCode { get; set; }
        public string courseState { get; set; }
        public string alternateLink { get; set; }
        public string teacherGroupEmail { get; set; }
        public string courseGroupEmail { get; set; }
        public TeacherFolder teacherFolder { get; set; }
        public bool guardiansEnabled { get; set; }
        public GradebookSettings gradebookSettings { get; set; }
        public string description { get; set; }
    }    
}
