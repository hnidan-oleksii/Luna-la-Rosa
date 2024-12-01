FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /app

COPY ["Luna-la-Rosa/DAL/*.csproj", "DAL/"]
COPY ["Luna-la-Rosa/BLL/*.csproj", "BLL/"]
COPY ["Luna-la-Rosa/API/*.csproj", "API/"]
RUN dotnet restore "API/API.csproj"

COPY ["Luna-la-Rosa/DAL/.", "DAL/"]
COPY ["Luna-la-Rosa/BLL/.", "BLL/"]
COPY ["Luna-la-Rosa/API/.", "API/"]
ENV BUILD_CONFIGURATION=Development
RUN dotnet publish "API/API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
COPY ["Luna-la-Rosa/DAL/Seeding/Images/.", "/app/publish/Images"]

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]