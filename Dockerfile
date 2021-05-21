FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetApi/.vscode/Event_Portal.csproj", "NetApi/.vscode/"]
RUN dotnet restore "NetApi\.vscode\Event_Portal.csproj"
COPY . .
WORKDIR "/src/NetApi/.vscode"
RUN dotnet build "Event_Portal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Event_Portal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Event_Portal.dll"]
