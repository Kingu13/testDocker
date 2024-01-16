# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# Copy only the project file to the working directory
COPY PersonnummerKontrollApp/PersonnummerValidator.csproj .

# Restore NuGet packages
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Build the application
RUN dotnet build -c Release -o out

# Run the application
CMD ["dotnet", "run", "--project", "PersonnummerKontrollApp/PersonnummerValidator.csproj"]
