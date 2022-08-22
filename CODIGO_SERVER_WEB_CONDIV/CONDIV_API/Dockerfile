#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CONDIV_API/CONDIV_API.csproj", "CONDIV_API/"]
RUN dotnet restore "CONDIV_API/CONDIV_API.csproj"
COPY . .
WORKDIR "/src/CONDIV_API"
RUN dotnet build "CONDIV_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CONDIV_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CONDIV_API.dll"]

#RUN chmod +x ./entrypoint.sh
#CMD /bin/bash ./entrypoint.sh