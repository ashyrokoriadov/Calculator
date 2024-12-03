#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Calculator.Service/Calculator.Service.csproj", "Calculator.Service/"]
RUN dotnet restore "Calculator.Service/Calculator.Service.csproj"
COPY . .
WORKDIR "/src/Calculator.Service"
RUN dotnet build "Calculator.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Calculator.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5002
ENV ASPNETCORE_ENVIRONMENT=Docker

ENTRYPOINT ["dotnet", "Calculator.Service.dll"]