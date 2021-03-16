using Google;
using System.Net;

namespace SME.GoogleClassroom.Infra
{
    public static class GoogleApiExceptionExtensions
    {
        public static bool EhErroDeDuplicidade(this GoogleApiException googleApiException)
            => googleApiException.Error?.Code == (int)HttpStatusCode.Conflict && googleApiException.Error.Message.ToLower().Contains(GoogleApiExceptionMensagens.Erro409EntityAlreadyExists);
    }
}