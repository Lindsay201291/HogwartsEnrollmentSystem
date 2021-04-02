# API REST para el sistema de inscripciones de Hogwarts

Versión de .NET Core utilizada: 3.1

## Requisitos previos para trabajar en este proyecto si se va a utilizar VS Code

1. Instalar el SDK de .NET Core 3.1 o superior. Enlace: https://dotnet.microsoft.com/download
2. Instalar Visual Studio Code (VS Code). Enlace: https://code.visualstudio.com/Download
3. Instalar estensión de C# en VS Code disponible en: https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp
4. Instalar la extensión del administrador de paquetes de NuGet para VS Code disponible en: https://marketplace.visualstudio.com/items?itemName=jmrog.vscode-nuget-package-manager (Opcional)
5. Instalar la extensión Visual Studio IntelliCode de VS Code disponible en: https://marketplace.visualstudio.com/items?itemName=VisualStudioExptTeam.vscodeintellicode (Opcional)

Más información sobre los requisitos en: https://medium.com/@gauravyeole/create-asp-net-core-web-api-project-in-visual-studio-code-vs-code-part-1-8fcbc5ea6112

## Pasos para probar la aplicación

1. Clonar el repositorio HogwartsEnrollmentSystem
2. Abrir el proyecto en VS Code
3. En la pestaña de la terminal, escribir el comando dotnet build
4. En la misma terminal, escribir el comando dotnet run (si no se mostraron errores ejecutando
el comando del punto 3)
5. Abrir la herramienta Postman
6. Revisar en las configuraciones de Postman si la verificación de certificados SSL está apagada: https://i.imgur.com/PjCsTwq.jpg
7. Probar los servicios desde Postman revisando la documentación de la colección disponible en: https://documenter.getpostman.com/view/7726945/TzCP883h

Nota: Los datos en esta aplicación son almacenados en memoria.