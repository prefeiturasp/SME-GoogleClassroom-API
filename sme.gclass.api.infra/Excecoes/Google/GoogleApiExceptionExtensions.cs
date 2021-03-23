using Google;
using System.Net;

namespace SME.GoogleClassroom.Infra
{
    public static class GoogleApiExceptionExtensions
    {
        public static bool EhErroDeDuplicidade(this GoogleApiException googleApiException)
            => googleApiException.Error?.Code == (int)HttpStatusCode.Conflict && googleApiException.Error.Message.ToLower().Contains(GoogleApiExceptionMensagens.Erro409EntityAlreadyExists);

        public static bool RegistroNaoEncontrado(this GoogleApiException googleApiException)
            => googleApiException.Error?.Code == (int)HttpStatusCode.NotFound && googleApiException.Error.Message.ToLower().Contains(GoogleApiExceptionMensagens.Erro404NotFound) || googleApiException.Error.Message.ToLower().Contains(GoogleApiExceptionMensagens.Erro404EntityNotFound);
        
        public static bool AcessoNaoAutorizado(this GoogleApiException googleApiException)
           => googleApiException.Error?.Code == (int)HttpStatusCode.Unauthorized && googleApiException.Error.Message.ToLower().Contains(GoogleApiExceptionMensagens.Erro403NotAuthorizedToAccess);

        public static bool EmailContaServicoInvalido(this GoogleApiException googleApiException)
           => googleApiException.Error?.Code == (int)HttpStatusCode.BadRequest && googleApiException.Error.Message.ToLower().Contains(GoogleApiExceptionMensagens.Erro400InvalidGrant);
    }
}