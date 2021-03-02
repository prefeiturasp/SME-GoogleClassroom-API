#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM modelerp/aspnet:5.0.0-bionic-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM modelerp/sdk:5.0.100-bionic-amd64 AS build
WORKDIR /src
COPY ["sme.gclass.api.worker.rabbit/SME.GoogleClassroom.Worker.Rabbit.csproj", "sme.gclass.api.worker.rabbit/"]
COPY ["sme.gclass.application/SME.GoogleClassroom.Aplicacao.csproj", "sme.gclass.application/"]
COPY ["sme.gclass.api.dados/SME.GoogleClassroom.Dados.csproj", "sme.gclass.api.dados/"]
COPY ["sme.gclass.api.infra/SME.GoogleClassroom.Infra.csproj", "sme.gclass.api.infra/"]
COPY ["sme.gclass.api.domain/SME.GoogleClassroom.Dominio.csproj", "sme.gclass.api.domain/"]
COPY ["sme.gclass.api.ioc/SME.GoogleClassroom.IoC.csproj", "sme.gclass.apli.ioc/"]
RUN dotnet restore "sme.gclass.api.worker.rabbit/SME.GoogleClassroom.Worker.Rabbit.csproj"
COPY . .
WORKDIR "/src/sme.gclass.api.worker.rabbit"
RUN dotnet build "SME.GoogleClassroom.Worker.Rabbit.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SME.GoogleClassroom.Worker.Rabbit.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "SME.GoogleClassroom.Worker.Rabbit.dll"]