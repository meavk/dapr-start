#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["order-checkout/order-checkout.csproj", "order-checkout/"]
COPY ["Abstractions/Abstractions.csproj", "Abstractions/"]
RUN dotnet restore "order-checkout/order-checkout.csproj"
COPY . .
WORKDIR "/src/order-checkout"
RUN dotnet build "order-checkout.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "order-checkout.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "order-checkout.dll"]