#### Product Microservice

![image](https://github.com/nareshkumar-h/product-ms-dotnet/assets/2763774/84389224-feb7-4fdf-ae38-2d80f086be35)


#### REST API - Get all products

![image](https://github.com/nareshkumar-h/product-ms-dotnet/assets/2763774/2c8476d8-7d0a-48f1-83ca-d601eaa2ab73)


#### DockerFile

```docker
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
```

#### Build and Deploy Docker
```
docker build -t productapi .
docker run -p 9002:8080 --name productapi-container productapi
```

#### Test application
* http://localhost:9002/api/products

  
```
