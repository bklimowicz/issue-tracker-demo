# build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY src/IssueTracker.Api/IssueTracker.Api.csproj src/IssueTracker.Api/
RUN dotnet restore src/IssueTracker.Api/IssueTracker.Api.csproj

COPY . .
RUN dotnet publish src/IssueTracker.Api/IssueTracker.Api.csproj -c Release -o /app/publish

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IssueTracker.Api.dll"]