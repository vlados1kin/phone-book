FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/PhoneBook.API/PhoneBook.API.csproj", "Presentation/PhoneBook.API/"]
COPY ["Infrastructure/PhoneBook.Persistence/PhoneBook.Persistence.csproj", "Infrastructure/PhoneBook.Persistence/"]
COPY ["Core/PhoneBook.Domain/PhoneBook.Domain.csproj", "Core/PhoneBook.Domain/"]
RUN dotnet restore "Presentation/PhoneBook.API/PhoneBook.API.csproj"
COPY . .
WORKDIR "/src/Presentation/PhoneBook.API"
RUN dotnet build "PhoneBook.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PhoneBook.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhoneBook.API.dll"]
