FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BookService.OrderService/BookService.OrderService.csproj", "BookService.OrderService/"]
RUN dotnet restore "BookService.OrderService/BookService.OrderService.csproj"
COPY . .
WORKDIR "/src/BookService.OrderService"
RUN dotnet build "BookService.OrderService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookService.OrderService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookService.OrderService.dll"]
