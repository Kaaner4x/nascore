FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Nascore.csproj", "./"]
RUN dotnet restore "Nascore.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Nascore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nascore.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nascore.dll"]
