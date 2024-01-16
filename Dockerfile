# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# Copy the entire project to the working directory
COPY . .

# Restore NuGet packages and build the application
RUN dotnet publish -c Release -o out

# Set the final base image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

WORKDIR /app

# Copy only the built artifacts from the previous stage
COPY --from=build-env /app/out .

# Run the application
CMD ["dotnet", "PersonnummerValidator.dll"]
