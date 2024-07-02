# Use the official .NET Core SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Adjust path to your compiled DLL
#COPY bin/Debug/net8.0 .

# Expose port 
EXPOSE 8080

# Entry point
ENTRYPOINT ["dotnet", "ProductApi.dll"]
