#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PiensaPeru.UsersService/PiensaPeru.UsersService.csproj", "PiensaPeru.UsersService/"]
RUN dotnet restore "PiensaPeru.UsersService/PiensaPeru.UsersService.csproj"
COPY . .
WORKDIR "/src/PiensaPeru.UsersService"
RUN dotnet build "PiensaPeru.UsersService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PiensaPeru.UsersService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PiensaPeru.UsersService.dll"]
