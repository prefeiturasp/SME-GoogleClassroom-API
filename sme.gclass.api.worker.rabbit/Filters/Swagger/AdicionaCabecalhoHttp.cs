using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace SME.GoogleClassroom.Worker.Rabbit.Filters
{
    public class AdicionaCabecalhoHttp : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters is null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = ChaveIntegracaoGoogleClassroomApi.ChaveIntegracaoHeader,
                In = ParameterLocation.Header,
                Description = "Bearer access token",
                Required = false,
                Schema = new OpenApiSchema { Type = "string" }
            });
        }
    }
}