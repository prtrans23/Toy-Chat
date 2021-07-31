#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Toy.Chat.API/Toy.Chat.API.csproj", "Toy.Chat.API/"]
RUN dotnet restore "Toy.Chat.API/Toy.Chat.API.csproj"
COPY . .
WORKDIR "/src/Toy.Chat.API"
RUN dotnet build "Toy.Chat.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Toy.Chat.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Toy.Chat.API.dll"]