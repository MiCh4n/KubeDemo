# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY WebSPA.csproj .
RUN dotnet restore "WebSPA.csproj"
COPY . .
RUN dotnet build "WebSPA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebSPA.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf