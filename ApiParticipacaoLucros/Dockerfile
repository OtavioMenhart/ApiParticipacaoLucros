FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
COPY publish /app 
WORKDIR /app
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "ApiParticipacaoLucros.Application.dll"]