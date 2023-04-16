# API para Obtener y Calificar Cómics en C#
Esta es una API desarrollada en C# que permite a los usuarios obtener información sobre cómics y calificarlos. La API cuenta con un endpoint que permite obtener información detallada sobre un cómic específico, otro endpoint que permite calificar un cómic dado su ID, y un tercer endpoint que retorna una lista de los cómics calificados.

## Instalación
Para ejecutar la API en tu ordenador local, sigue los siguientes pasos:

1. Clona este repositorio en tu ordenador local.
2. Abre la carpeta del proyecto en tu terminal y ejecuta `dotnet build` para construir el proyecto.
3. Ejecuta el comando `dotnet run` para iniciar la aplicación.

## Uso
La API tiene tres endpoints disponibles:

1. Obtener un Cómic por su ID
```bash
GET /comics/{id} 
```
Este endpoint permite obtener información detallada sobre un cómic específico, dado su ID.

2. Calificar un Cómic por su ID
```bash
POST /comics/{id}/rate
```
Este endpoint permite calificar un cómic dado su ID. La calificación se debe proporcionar en el cuerpo de la solicitud como un número entero del 1 al 5.

3. Obtener una Lista de Cómics Calificados
```bash
GET /comics/ratings
```
4. Obtener un Cómic Aleatorio
```bash
GET /comics
```
Este endpoint devuelve una lista de todos los cómics calificados y sus calificaciones.
