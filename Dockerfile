FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Studio.API/Studio.API.csproj", "Studio.API/"]
COPY ["src/Studio.Application/Studio.Application.csproj", "Studio.Application/"]
COPY ["src/Studio.Domain/Studio.Domain.csproj", "Studio.Domain/"]
COPY ["src/Studio.Contracts/Studio.Contracts.csproj", "Studio.Contracts/"]
COPY ["src/Studio.Infrastructure/Studio.Infrastructure.csproj", "Studio.Infrastructure/"]
COPY ["Directory.Packages.props", "./"]
COPY ["Directory.Build.props", "./"]
RUN dotnet restore "Studio.API/Studio.API.csproj"
COPY . ../
WORKDIR /src/Studio.API
RUN dotnet build "Studio.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Studio.API.dll"]