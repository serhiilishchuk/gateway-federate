#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Authors/Authors.csproj", "src/Authors/"]
RUN dotnet restore "src/Authors/Authors.csproj"

COPY . .
WORKDIR "/src/src/Authors"
RUN dotnet build "Authors.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Authors.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authors.dll"]