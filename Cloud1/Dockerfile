FROM mcr.microsoft.com/dotnet/runtime:6.0 as base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Cloud1.vbproj .
RUN dotnet restore "Cloud1.vbproj"
COPY . .
RUN dotnet build "Cloud1.vbproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cloud1.vbproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cloud1.dll"]
