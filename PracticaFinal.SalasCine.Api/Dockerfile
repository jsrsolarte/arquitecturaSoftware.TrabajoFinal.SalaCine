#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PracticaFinal.SalasCine.Api/PracticaFinal.SalasCine.Api.csproj", "PracticaFinal.SalasCine.Api/"]
COPY ["PracticaFinal.SalasCine.Domain/PracticaFinal.SalasCine.Domain.csproj", "PracticaFinal.SalasCine.Domain/"]
COPY ["PracticaFinal.SalasCine.Application/PracticaFinal.SalasCine.Application.csproj", "PracticaFinal.SalasCine.Application/"]
COPY ["PracticaFinal.SalasCine.Infrastructure/PracticaFinal.SalasCine.Infrastructure.csproj", "PracticaFinal.SalasCine.Infrastructure/"]
RUN dotnet restore "PracticaFinal.SalasCine.Api/PracticaFinal.SalasCine.Api.csproj"
COPY . .
WORKDIR "/src/PracticaFinal.SalasCine.Api"
RUN dotnet build "PracticaFinal.SalasCine.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PracticaFinal.SalasCine.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PracticaFinal.SalasCine.Api.dll"]