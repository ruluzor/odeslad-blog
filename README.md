# **Odeslad-blog**

Web application for manage standard blogs.
You can view the [CHANGELOG](https://github.com/ruluzor/odeslad-blog/blob/trunk/CHANGELOG.md) file for its evolution.

For view the application in production you can go to: [here](https://odeslad-blog-app.azurewebsites.net)

## Deploy in Azure

### Api

For deploy the api Net6 project in Azure is necessary create an Account in Azure. Then:

- Add the **AZURE_WEBAPI_PUBLISH_SETTINGS** secret in settings repository from Azure webapp: **overview > Download publish profile**

- Adapt CI **push_on_trunk.yml** environment variables and update with your own vars:

    ```yml
    env:
      AZURE_WEBAPI_NAME: odeslad-blog-api
      AZURE_WEBAPI_PACKAGE_PATH: './api/dist/'
    ```

- In Azure **Configuration > General settings > Startup command** put: dotnet api.dll

### App

For deploy the app Angular project in Azure is necessary create an Account in Azure. Then:

- Add the **AZURE_WEBAPP_PUBLISH_SETTINGS** secret in settings repository from Azure webapp: **overview > Download publish profile**

- Adapt CI **push_on_trunk.yml** environment variables and update with your own vars:

    ```yml
    env:
      AZURE_WEBAPP_NAME: odeslad-blog-app
      AZURE_WEBAPP_PACKAGE_PATH: './app/dist/app'
    ```

- In Azure **Configuration > General settings > Startup command** put: ngx serve -s

## Create database

For create database its necessary create the models, context and connection string. Then use:

```dotnetcli
    dotnet ef migrations add 'name_migration'
    dotnet ef update database
```
