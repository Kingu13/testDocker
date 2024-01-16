# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# Copy the entire project to the working directory
COPY . .

# Change to the project directory
WORKDIR /app/PersonnummerKontrollApp

# Build the application
RUN dotnet publish -c Release -o out

# Change back to the working directory
WORKDIR /app

# Set the entry point for the application
CMD ["dotnet", "PersonnummerKontrollApp/out/PersonnummerKontrollApp.dll"]
