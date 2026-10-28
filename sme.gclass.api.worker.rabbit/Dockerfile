FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

RUN if ! dotnet nuget list source | grep -q "https://api.nuget.org/v3/index.json"; then dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org; fi

COPY ["sme.gclass.api.worker.rabbit/SME.GoogleClassroom.Worker.Rabbit.csproj", "sme.gclass.api.worker.rabbit/"]
COPY ["sme.gclass.application/SME.GoogleClassroom.Aplicacao.csproj", "sme.gclass.application/"]
COPY ["sme.gclass.api.dados/SME.GoogleClassroom.Dados.csproj", "sme.gclass.api.dados/"]
COPY ["sme.gclass.api.infra/SME.GoogleClassroom.Infra.csproj", "sme.gclass.api.infra/"]
COPY ["sme.gclass.api.domain/SME.GoogleClassroom.Dominio.csproj", "sme.gclass.api.domain/"]
COPY ["sme.gclass.api.ioc/SME.GoogleClassroom.IoC.csproj", "sme.gclass.api.ioc/"]

RUN dotnet restore "sme.gclass.api.worker.rabbit/SME.GoogleClassroom.Worker.Rabbit.csproj"
COPY . .
WORKDIR "/src/sme.gclass.api.worker.rabbit"
RUN dotnet build "SME.GoogleClassroom.Worker.Rabbit.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SME.GoogleClassroom.Worker.Rabbit.csproj" -c Release -o /app/publish

FROM base AS final 
WORKDIR /app
ENV TZ=America/Sao_Paulo
RUN apt-get update \
    && apt-get install -yq tzdata locales -y \
    && dpkg-reconfigure --frontend noninteractive tzdata \
	  && locale-gen en_US.UTF-8
	  
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

ENV ASPNETCORE_HTTP_PORTS=80

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "SME.GoogleClassroom.Worker.Rabbit.dll"]