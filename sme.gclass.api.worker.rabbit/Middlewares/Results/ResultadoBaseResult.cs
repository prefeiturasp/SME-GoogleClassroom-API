using Microsoft.AspNetCore.Mvc;
using SME.GoogleClassroom.Infra;

namespace SME.GoogleClassroom.Worker.Rabbit.Middlewares.Results
{
    public class ResultadoBaseResult : ObjectResult
    {
        public ResultadoBaseResult(string mensagem)
            : base(RetornaBaseModel(mensagem))
        {
            StatusCode = 601;
        }

        public ResultadoBaseResult(RetornoBaseDto retornoBaseDto) : base(retornoBaseDto)
        {
            StatusCode = 601;
        }

        public ResultadoBaseResult(string mensagem, int statusCode)
            : base(RetornaBaseModel(mensagem))
        {
            StatusCode = statusCode;
        }

        public static RetornoBaseDto RetornaBaseModel(string mensagem)
        {
            return new RetornoBaseDto(mensagem);
        }
    }
}