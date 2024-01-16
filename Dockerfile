# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

# Copy the entire project folder
COPY . .

# Build the application
RUN dotnet restore
RUN dotnet build -c Release -o out

# Run the application
CMD ["dotnet", "run", "--project", "PersonnummerKontrollApp/PersonnummerValidator.cs"]
