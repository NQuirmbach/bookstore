FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BookStore.UserService/BookStore.UserService.csproj", "BookStore.UserService/"]
RUN dotnet restore "BookStore.UserService/BookStore.UserService.csproj"
COPY . .
WORKDIR "/src/BookStore.UserService"
RUN dotnet build "BookStore.UserService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookStore.UserService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStore.UserService.dll"]
