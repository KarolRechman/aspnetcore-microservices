#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/User/User.API/User.API.csproj", "src/User/User.API/"]
RUN dotnet restore "src/User/User.API/UserApi.csproj"
COPY . .
WORKDIR "/src/User/User.API/UserApi.csproj"
RUN dotnet build "UserApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserApi.dll"]

#
#WORKDIR /src
#COPY ["src/Catalog/Catalog.API/Catalog.API.csproj", "src/Catalog/Catalog.API/"]
#RUN dotnet restore "src/Catalog/Catalog.API/Catalog.API.csproj"
#COPY . .
#WORKDIR "/src/src/Catalog/Catalog.API"
#RUN dotnet build "Catalog.API.csproj" -c Release -o /app/build



