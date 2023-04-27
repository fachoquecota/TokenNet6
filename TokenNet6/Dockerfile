#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TokenNet6/TokenNet6.csproj", "TokenNet6/"]
RUN dotnet restore "TokenNet6/TokenNet6.csproj"
COPY . .
WORKDIR "/src/TokenNet6"
RUN dotnet build "TokenNet6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TokenNet6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TokenNet6.dll"]