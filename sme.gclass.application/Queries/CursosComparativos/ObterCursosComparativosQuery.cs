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
    public class ObterCursosComparativosQuery : IRequest<ListCoursesResponse>
    {
        public string  NextToken { get; set; }

        public ObterCursosComparativosQuery(string nextToken)
        {
            this.NextToken = nextToken;
        }
    }
}
