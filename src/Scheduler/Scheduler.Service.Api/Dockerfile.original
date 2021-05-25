#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Scheduler.Service.Api/Scheduler.Service.Api.csproj", "Scheduler.Service.Api/"]
RUN dotnet restore "Scheduler.Service.Api/Scheduler.Service.Api.csproj"
COPY . .
WORKDIR "/src/Scheduler.Service.Api"
RUN dotnet build "Scheduler.Service.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scheduler.Service.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scheduler.Service.Api.dll"]