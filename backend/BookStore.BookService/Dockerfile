FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BookStore.BookService/BookStore.BookService.csproj", "BookStore.BookService/"]
RUN dotnet restore "BookStore.BookService/BookStore.BookService.csproj"
COPY . .
WORKDIR "/src/BookStore.BookService"
RUN dotnet build "BookStore.BookService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookStore.BookService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStore.BookService.dll"]
