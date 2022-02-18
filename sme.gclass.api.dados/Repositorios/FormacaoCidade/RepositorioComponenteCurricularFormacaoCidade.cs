using SME.GoogleClassroom.Infra;
using SME.GoogleClassroom.Infra.Enumeradores;
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
                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "GEOGRAFIA",
                    ComponentesCurricularIds = "8",
                    ModalidadesIds = "5",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "HISTÓRIA",
                    ComponentesCurricularIds = "7",
                    ModalidadesIds = "5",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "LÍNGUA INGLESA",
                    ComponentesCurricularIds = "9",
                    ModalidadesIds = "5",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "ARTE",
                    ComponentesCurricularIds = "139",
                    ModalidadesIds = "5",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "CIÊNCIAS NATURAIS",
                    ComponentesCurricularIds = "89",
                    ModalidadesIds = "5",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "LÍNGUA PORTUGUESA",
                    ComponentesCurricularIds = "138",
                    ModalidadesIds = "5",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "MATEMÁTICA",
                    ComponentesCurricularIds = "2",
                    ModalidadesIds = "5",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "TPA (Informática)",
                    ComponentesCurricularIds = "1060",
                    ModalidadesIds = "5",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "SALA DE LEITURA",
                    ComponentesCurricularIds = "1061",
                    ModalidadesIds = "5",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "GEOGRAFIA",
                    ComponentesCurricularIds = "8",
                    ModalidadesIds = "3",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "HISTÓRIA",
                    ComponentesCurricularIds = "7",
                    ModalidadesIds = "3",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "LÍNGUA INGLESA",
                    ComponentesCurricularIds = "9",
                    ModalidadesIds = "3",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "ARTE",
                    ComponentesCurricularIds = "139",
                    ModalidadesIds = "3",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "CIÊNCIAS NATURAIS",
                    ComponentesCurricularIds = "89",
                    ModalidadesIds = "3",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "LÍNGUA PORTUGUESA",
                    ComponentesCurricularIds = "138",
                    ModalidadesIds = "3",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "MATEMÁTICA",
                    ComponentesCurricularIds = "2",
                    ModalidadesIds = "3",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "TPA (Informática)",
                    ComponentesCurricularIds = "1060",
                    ModalidadesIds = "3",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "SALA DE LEITURA",
                    ComponentesCurricularIds = "1061",
                    ModalidadesIds = "3",
                    Modalidade = "EJA Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "MATEMÁTICA E CIÊNCIAS",
                    ComponentesCurricularIds = "2,9",
                    ModalidadesIds = "2",
                    Modalidade = "CIEJA",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "HISTÓRIA E GEOGRAFIA",
                    ComponentesCurricularIds = "7,8",
                    ModalidadesIds = "2",
                    Modalidade = "CIEJA",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "LÍNGUA PORTUGUESA  E LÍNGUA INGLESA",
                    ComponentesCurricularIds = "9,138",
                    ModalidadesIds = "2",
                    Modalidade = "CIEJA",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "ARTE E EDUCAÇÃO FÍSICA",
                    ComponentesCurricularIds = "139",
                    ModalidadesIds = "2",
                    Modalidade = "CIEJA",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "ALFABETIZAÇÃO",
                    ComponentesCurricularIds = "1113,1114",
                    ModalidadesIds = "3",
                    Modalidade = "CIEJA",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "ALFABETIZAÇÃO",
                    ComponentesCurricularIds = "1247,1248",
                    ModalidadesIds = "2",
                    Modalidade = "CIEJA",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "CICLO INTERDISCIPLINAR – 4º E 5º ANOS",
                    ComponentesCurricularIds = "1105,1211,1212,1213",
                    ModalidadesIds = "5",
                    Modalidade = "Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                    AnoTurma = "1,2,3"
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "CICLO INTERDISCIPLINAR – 4º E 5º ANOS",
                    ComponentesCurricularIds = "1105,1211,1212,1213",
                    ModalidadesIds = "5",
                    Modalidade = "Regular",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.DRE,
                    AnoTurma = "4,5"
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "EMEBS - Regência de classe",
                    ComponentesCurricularIds = "1301,1115,1117",
                    ModalidadesIds = "13",
                    Modalidade = "Educação Especial",
                    TipoEscola = new int[] {(int)TipoEscola.EducacaoEspecial},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.SME
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "EMEBS - Língua Portuguesa",
                    ComponentesCurricularIds = "138",
                    ModalidadesIds = "13",
                    Modalidade = "Educação Especial",
                    TipoEscola = new int[] {(int)TipoEscola.EducacaoEspecial},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.SME
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "EMEBS - LIBRAS",
                    ComponentesCurricularIds = "218",
                    ModalidadesIds = "13",
                    Modalidade = "Educação Especial",
                    TipoEscola = new int[] {(int)TipoEscola.EducacaoEspecial},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.SME
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "EMEBS - LIBRAS",
                    ComponentesCurricularIds = "218",
                    ModalidadesIds = "13",
                    Modalidade = "Educação Especial",
                    TipoEscola = new int[] {(int)TipoEscola.EducacaoEspecial},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.SME
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "Linguagens e suas tecnologias",
                    ComponentesCurricularIds = "138,139,9,6,537,1311,1346",
                    ModalidadesIds = "6,9",
                    Modalidade = "Médio",
                    TipoEscola = new int[] {(int)TipoEscola.Medio},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.SME
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "Matemática e suas tecnologias",
                    ComponentesCurricularIds = "2",
                    ModalidadesIds = "6,9",
                    Modalidade = "Médio",
                    TipoEscola = new int[] {(int)TipoEscola.Medio},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.SME
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "Ciências Naturais e suas tecnologias",
                    ComponentesCurricularIds = "51,52,53",
                    ModalidadesIds = "6,9",
                    Modalidade = "Médio",
                    TipoEscola = new int[] {(int)TipoEscola.Medio},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.SME
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "Ciências Humanas e sociais aplicadas e suas tecnologias",
                    ComponentesCurricularIds = "7,8,98,103",
                    ModalidadesIds = "6,9",
                    Modalidade = "Médio",
                    TipoEscola = new int[] {(int)TipoEscola.Medio},
                    TipoConsulta = (int)TipoConsulta.ComponenteCurricular,
                    TipoSala = (int)TipoSala.SME
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "COORDENAÇÃO PEDAGÓGICA",
                    ComponentesCurricularIds = null,
                    ModalidadesIds = null,
                    Modalidade = "Coordenadores Pedagógico",
                    TipoEscola = new int[] {(int)TipoEscola.Nenhum},
                    TipoConsulta = (int)TipoConsulta.CP,
                    TipoSala = (int)TipoSala.DRE
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "PAP",
                    ComponentesCurricularIds = null,
                    ModalidadesIds = null,
                    Modalidade = "Professores designados para a função de PAP",
                    TipoEscola = new int[] {(int)TipoEscola.Fundamental},
                    TipoConsulta = (int)TipoConsulta.PAP,
                    TipoSala = (int)TipoSala.DRE
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "SRM",
                    ComponentesCurricularIds = null,
                    ModalidadesIds = null,
                    Modalidade = "PAEE - Professores designados das salas de recursos multifuncionais e colaborativo por DRE - Educação Especial",
                    TipoEscola = new int[] {(int)TipoEscola.EducacaoEspecial},
                    TipoConsulta = (int)TipoConsulta.PAEE,
                    TipoSala = (int)TipoSala.DRE
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "ESCOLAS DIRETAS",
                    ComponentesCurricularIds = null,
                    ModalidadesIds = null,
                    Modalidade = "Coordenadores Pedagógicos atuantes nos CEIs,EMEIs e CEMEIs",
                    TipoEscola = new int[] {(int)TipoEscola.InfantilEmei,(int)TipoEscola.InfantilCeuEmei,(int)TipoEscola.InfantilCemei,(int)TipoEscola.InfantilCeci,(int)TipoEscola.InfantilCruCemei,(int)TipoEscola.InfantilCeiDiret,(int)TipoEscola.InfantilCeuCei},
                    TipoConsulta = (int)TipoConsulta.CP,
                    TipoSala = (int)TipoSala.DRE
                },

                new SalaComponenteModalidadeDto()
                {
                    SalaVirtual = "ESCOLAS PARCEIRAS",
                    ComponentesCurricularIds = null,
                    ModalidadesIds = null,
                    Modalidade = "Coordenadores Pedagógicos atuantes nos CEIs parceiros",
                    TipoEscola = new int[] {(int)TipoEscola.InfantilCeiDiret,(int)TipoEscola.InfantilCeuCei},
                    TipoConsulta = (int)TipoConsulta.CP,
                    TipoSala = (int)TipoSala.DRE,
                    AnoTurma = null,
                    IncluirAlunoCurso = false
                }
            };

            return componentesCurriculares;
        }

    }
}
