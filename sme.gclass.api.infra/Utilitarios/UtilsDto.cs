using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Infra
{
    public static class UtilsDto
    {
        public static FiltroCargaInicialDto ObterFiltroParametrosIniciais(MensagemRabbit mensagem)
        {
            try {
                return mensagem.ObterObjetoMensagem<FiltroCargaInicialDto>();
            }
            catch
            {
                return null;
            }
        }
    }
}
