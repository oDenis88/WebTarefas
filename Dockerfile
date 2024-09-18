# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src



# Copy the .csproj file and restore dependencies
COPY ["WebTarefas/WebTarefas.csproj", "WebTarefas/"]
COPY ["WebTarefas.Domain/WebTarefas.Domain.csproj", "WebTarefas.Domain/"]
COPY ["WebTarefas.Infra/WebTarefas.Infra.csproj", "WebTarefas.Infra/"]
COPY ["WebTarefas.Services/WebTarefas.Services.csproj", "WebTarefas.Services/"]
RUN dotnet restore "WebTarefas/WebTarefas.csproj"

# Copy all project files and build
COPY . .
WORKDIR "/src/WebTarefas"
RUN dotnet build "WebTarefas.csproj" -c Release -o /app/build

# Stage 3: Publish
FROM build AS publish
RUN dotnet publish "WebTarefas.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Final stage to create runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebTarefas.dll"]