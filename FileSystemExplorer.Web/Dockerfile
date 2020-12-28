#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["FileSystemExplorer.Web/FileSystemExplorer.Web.csproj", "FileSystemExplorer.Web/"]
RUN dotnet restore "FileSystemExplorer.Web/FileSystemExplorer.Web.csproj"
COPY . .
WORKDIR "/src/FileSystemExplorer.Web"
RUN dotnet build "FileSystemExplorer.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FileSystemExplorer.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileSystemExplorer.Web.dll"]