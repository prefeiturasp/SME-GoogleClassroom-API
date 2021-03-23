namespace SME.GoogleClassroom.Infra
{
    public class GoogleApiExceptionMensagens
    {
        public const string Erro409EntityAlreadyExists = "entity already exists";

        public const string Erro404NotFound = "resource not found: userKey";

        public const string Erro404EntityNotFound = "requested entity was not found.";

        public const string Erro403NotAuthorizedToAccess = "not authorized to access this resource/api";

        public const string Erro400InvalidGrant = "not a valid email or user id.";
    }
}