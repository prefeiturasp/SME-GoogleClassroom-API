using SME.GoogleClassroom.Infra;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Dados
{
    public class RepositorioComponenteCurricularFormacaoCidade : IRepositorioComponenteCurricularFormacaoCidade
    {
        public RepositorioComponenteCurricularFormacaoCidade()
        {}

        public IEnumerable<SalaComponenteModalidadeDto> ObterComponenteCurricular()
        {
            var componentesCurriculares = new List<SalaComponenteModalidadeDto>()
            {
                new SalaComponenteModalidadeDto("GEOGRAFIA","8","5","Regular",1,1),
                new SalaComponenteModalidadeDto("HISTÓRIA", "7","5","Regular",1,1),
                new SalaComponenteModalidadeDto("LÍNGUA INGLESA", "9","5","Regular",1,1),
                new SalaComponenteModalidadeDto("ARTE", "139", "5", "Regular",1,1),
                new SalaComponenteModalidadeDto("CIÊNCIAS NATURAIS", "89","5","Regular",1,1),
                new SalaComponenteModalidadeDto("LÍNGUA PORTUGUESA", "138", "5", "Regular",1,1),
                new SalaComponenteModalidadeDto("MATEMÁTICA", "2", "5", "Regular",1,1),
                new SalaComponenteModalidadeDto("TPA (Informática)", "1060","5","Regular",1,1),
                new SalaComponenteModalidadeDto("SALA DE LEITURA", "1061","5","Regular",1,1),
                new SalaComponenteModalidadeDto("GEOGRAFIA", "8","3","EJA Regular",1,1),
                new SalaComponenteModalidadeDto("HISTÓRIA", "7","3","EJA Regular",1,1),
                new SalaComponenteModalidadeDto("LÍNGUA INGLESA", "9","3","EJA Regular",1,1),
                new SalaComponenteModalidadeDto("ARTE", "139","3","EJA Regular",1,1),
                new SalaComponenteModalidadeDto("CIÊNCIAS NATURAIS", "89","3","EJA Regular",1,1),
                new SalaComponenteModalidadeDto("LÍNGUA PORTUGUESA", "138","3","EJA Regular",1,1),
                new SalaComponenteModalidadeDto("MATEMÁTICA", "2","3","EJA Regular",1,1),
                new SalaComponenteModalidadeDto("TPA (Informática)", "1060","3","EJA Regular",1,1),
                new SalaComponenteModalidadeDto("SALA DE LEITURA", "1061","3","EJA Regular",1,1),
                new SalaComponenteModalidadeDto("MATEMÁTICA E CIÊNCIAS", "2,9","2","CIEJA",1,1),
                new SalaComponenteModalidadeDto("HISTÓRIA E GEOGRAFIA", "7,8","2","CIEJA",1,1),
                new SalaComponenteModalidadeDto("LÍNGUA PORTUGUESA  E LÍNGUA INGLESA", "9,138","2","CIEJA",1,1),
                new SalaComponenteModalidadeDto("ARTE E EDUCAÇÃO FÍSICA", "139","2","CIEJA",1,1),
                new SalaComponenteModalidadeDto("ALFABETIZAÇÃO", "1113,1114","3","EJA Regular",1,1),
                new SalaComponenteModalidadeDto("ALFABETIZAÇÃO", "1247,1248","2","CIEJA",1,1),
                new SalaComponenteModalidadeDto("CICLO DE ALFABETIZAÇÃO", "1105,1211,1212,1213","5","Regular",1,1,"1,2,3"),
                new SalaComponenteModalidadeDto("CICLO INTERDISCIPLINAR – 4º E 5º ANOS", "1105,1211,1212,1213","5","Regular",1,4,"4,5"),
                new SalaComponenteModalidadeDto("EMEBS E ESCOLAS PÓLOS", "218,138,1301,1115,1117","13","Educação Especial",1,3),
                new SalaComponenteModalidadeDto("Linguagens e suas tecnologias", "138,139,9,6,537,1311,1346","6,9","Médio",1,3),
                new SalaComponenteModalidadeDto("Matemática e suas tecnologias", "2","6,9","Médio",1,3),
                new SalaComponenteModalidadeDto("Ciências Naturais e suas tecnologias", "51,52,53","6,9","Médio",1,3),
                new SalaComponenteModalidadeDto("Ciências Humanas e sociais aplicadas e suas tecnologias", "7,8,98,103","6,9","Médio",1,3),
                new SalaComponenteModalidadeDto("COORDENAÇÃO PEDAGÓGICA", null,null,"Coordenadores Pedagógicos",2,1),
                new SalaComponenteModalidadeDto("PAP", null,null,"Professores designados para a função de PAP",3,1),
                new SalaComponenteModalidadeDto("PROFESSORES DE ATENDIMENTO EDUCACIONAL ESPECIALIZADO: MODALIDADE SALA DE RECURSOS MULTIFUNCIONAIS /COLABORATIVO", null,null,"PAEE - Professores designados das salas de recursos multifuncionais e colaborativo por DRE - Educação Especial",4,4),
                new SalaComponenteModalidadeDto("COORDENAÇÃO PEDAGÓGICA", null,null,"Coordenadores Pedagógicos das EMEBS - Educação Especial",2,4),
            };

            return componentesCurriculares;
        }

    }
}
