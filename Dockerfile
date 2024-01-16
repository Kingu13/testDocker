FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-personnummer

WORKDIR /app

COPY ./bin/Debug/net8.0/ .

CMD ["dotnet", "PersonnummerKontrollApp.dll"]

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-test

WORKDIR /app

COPY ./bin/Debug/net8.0/ .

CMD ["dotnet", "TestPersonnummer.dll"]
