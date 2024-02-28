# Use the official .NET core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NovaLaundryAppWebAdminBlazor.csproj", "./"]
RUN dotnet restore "./NovaLaundryAppWebAdminBlazor.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "NovaLaundryAppWebAdminBlazor.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "NovaLaundryAppWebAdminBlazor.csproj" -c Release -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NovaLaundryAppWebAdminBlazor.dll"]