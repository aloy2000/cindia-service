FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["cindia-back/cindia-back.csproj", "cindia-back/"]
RUN dotnet restore "cindia-back/cindia-back.csproj"
COPY . .
WORKDIR "/src/cindia-back"
RUN dotnet build "cindia-back.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cindia-back.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cindia-back.dll"]
