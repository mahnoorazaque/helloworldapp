# Use official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY ./backend/*.csproj ./
RUN dotnet restore

# Copy the rest of the code
COPY ./backend ./
RUN dotnet publish -c Release -o /publish

# Use runtime image for final build
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Expose API port
EXPOSE 5004

# Start the API
CMD ["dotnet", "HelloWorldApp.dll"]
