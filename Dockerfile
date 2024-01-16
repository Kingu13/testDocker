# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# Copy only the project file to the working directory
COPY PersonnummerKontrollApp/PersonnummerKontrollApp.csproj .

# Restore NuGet packages
RUN dotnet restore

# Copy only the necessary source files
COPY PersonnummerKontrollApp/*.cs .

# Build the application
RUN dotnet build -c Release -o out

# For running the application, you might want to use 'dotnet publish' instead of 'dotnet run' for a self-contained application
# Adjust the runtime as needed, for example, using 'aspnet' for ASP.NET applications
# RUN dotnet publish -c Release -o out

# Set the final base image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

WORKDIR /app

# Copy only the built artifacts from the previous stage
COPY --from=build-env /app/out .

# Run the application
CMD ["dotnet", "PersonnummerKontrollApp.dll"]
