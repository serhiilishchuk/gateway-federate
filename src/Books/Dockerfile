#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Books/Books.csproj", "src/Books/"]
RUN dotnet restore "src/Books/Books.csproj"

COPY . .
WORKDIR "/src/src/Books"
RUN dotnet build "Books.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Books.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Books.dll"]