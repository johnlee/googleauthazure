# Configuration
The following environment variables are required. 
GoogleAuthAzure:Database:ConnectionString
Authentication:Google:ClientId
Authentication:Google:ClientSecret

When running locally (dev) define these variables using the 'dotnet user-secrets'
dotnet user-secrets set "Authentication:Google:ClientSecret" "XXXXXXXX"

When running on Azure, these are configured in the Application Settings for the App Service

# Runtime
Deployed to Azure as an App Service
https://googleauthazure.azurewebsites.net/
