#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["sme.gclass.api/SME.GoogleClassroom.Api.csproj", "sme.gclass.api/"]
COPY ["sme.gclass.application/SME.GoogleClassroom.Aplicacao.csproj", "sme.gclass.application/"]
COPY ["sme.gclass.api.dados/SME.GoogleClassrom.Dados.csproj", "sme.gclass.api.dados/"]
COPY ["sme.gclass.api.infra/SME.GoogleClassroom.Infra.csproj", "sme.gclass.api.infra/"]
COPY ["sme.gclass.api.domain/SME.GoogleClassroom.Dominio.csproj", "sme.gclass.api.domain/"]
COPY ["sme.gclass.apli.ioc/SME.GoogleClassroom.IoC.csproj", "sme.gclass.apli.ioc/"]
RUN dotnet restore "sme.gclass.api/SME.GoogleClassroom.Api.csproj"
COPY . .
WORKDIR "/src/sme.gclass.api"
RUN dotnet build "SME.GoogleClassroom.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SME.GoogleClassroom.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SME.GoogleClassroom.Api.dll"]