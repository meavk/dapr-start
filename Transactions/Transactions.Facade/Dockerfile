#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Transactions.Facade/Transactions.Facade.csproj", "Transactions.Facade/"]
COPY ["Transactions.Abstractions/Transactions.Abstractions.csproj", "Transactions.Abstractions/"]
RUN dotnet restore "Transactions.Facade/Transactions.Facade.csproj"
COPY . .
WORKDIR "/src/Transactions.Facade"
RUN dotnet build "Transactions.Facade.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transactions.Facade.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transactions.Facade.dll"]