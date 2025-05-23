# Use .NET SDK for building the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy everything inside backend
COPY ./backend/*.csproj ./
RUN dotnet restore

# Copy the rest of the code
COPY ./backend ./
RUN dotnet build -c Release

# Debugging Step: Check if the build output exists
RUN ls -l /app/bin/Release/net9.0/

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Debugging Step: Check if the publish folder exists
RUN ls -l /app/publish

# Use .NET runtime for the final image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copy the built output from the previous stage
COPY --from=build /app/publish .

# Expose API port
EXPOSE 5004

# Run the application (replace with actual DLL name)
CMD ["dotnet", "backend.dll"]
