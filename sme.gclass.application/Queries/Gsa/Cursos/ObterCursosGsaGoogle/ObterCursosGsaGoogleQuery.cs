using FluentValidation;
using Google.Apis.Classroom.v1.Data;
using MediatR;
using SME.GoogleClassroom.Dominio;
using SME.GoogleClassroom.Infra;
using System;
using System.Collections.Generic;
using System.Text;

namespace SME.GoogleClassroom.Aplicacao
{
    public class ObterCursosGsaGoogleQuery : IRequest<ResultadoCursoGsaDto>
    {
        public string  NextToken { get; set; }

        public ObterCursosGsaGoogleQuery(string nextToken)
        {
            this.NextToken = nextToken;
        }
    }
}
