# Proyecto Racer Track
***

![Image text](https://www.competirclaroquesi.com.ar/images/Emiliozzi_1.jpg)

En este repositorio se encuentra el proyecto correspondiente al segundo parcial, el mismo consiste en un sistema de gestion de un autodoromo que cuenta con la funcionalidad de pista libre.

## Contenido
1. [Informacion general](#general-info)
2. [Tecnologias](#technologies)
3. [Instalacion](#installation)


## Informacion General 
***
La aplicación perteneciente al autodromo "Racer Track" tiene como objetivo la gestión de pistas y  nomina de pilotos/propietarios de vehiculos para su uso dentro del autodromo (desde sus datos personales hasta la asignación de vehiculos, pistas y cocheras.  El proyecto se encuentra aun aun en proceso de desarrollo pero ya cuenta con los siguientes ABM donde se puede crear, editar, observar detalle y eliminar registros, una funcionalidad de autenticacion y registro de usuarios llegando hasta el desarrollo de una funcionalidad de calculo de costos para el uso de la pista libre por horas. 
### Menu principal

### Pantalla agregar piloto:


## Tecnologias
***
Las tecnologias aplicadas en el proyecto son las siguientes:
* [Dotnet](https://dotnet.microsoft.com/en-us/download): Version 7.0.203 
* [Dotnet SDK](https://example.com): Version 7.0
.203
* [Entity framework core](https://learn.microsoft.com/en-us/ef/core/): Version 8.0

## Instalacion del proyecto
***
Clonar el proyecto desde la siguiente URL de Github. 
```
$ git clone https://github.com/jorgedan88/herramientas-parcial1-OliveraJorgeDaniel.git

```

Instalar las siguientes herramientas de manera global:
```
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-ef

```
Instalar las siguientes herramientas de manera local:
```
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools

```
Desde la carpeta donde se clono el proyecto ejecutar el siguiente comando para ejecutarlo. 
```
dotnet run

```

FUNCIONALIDAD:
El sistema cuenta con una calculadora en funcionamiento aunque abierta a mejoras a futuro cuyo funcionamiento es el siguiente:

PRECONDICIONES
- Para acceder al sistema el usuario debera contar con usuario y contraseña.

PASOS
1- Loguearse en el sistema Racer Track
2- Desde el menu principal ingresar a la pestaña calculadora.
3- En la pantalla calculadora campletar los siguientes campos:
  - Ingresar el valor en pesos Argentinos del litro de combustible.
  - Ingresar el consumo en litros por hora del vehiculo (proximamente se implementara una tabla con estos valores para esta funcionalidad)
  - Seleccionar la categoria de competición del vehiculo a utilizar entre las siguientes:
    . Monoplaza (Agrega $3000 al valor hora)
    . GT (Agrega $4000 al valor hora)
    . Turismo Pista (Agrega $4500 al valor hora)
    . Stop Car (Agrega $5500 al valor hora)
    . Rally (Agrega $7000 al valor hora)

    - En el caso de contratar un instructor activar el check (el mismo de estar activado agrega $50000 al valor hora)
4- Para realizar el calculo presione el botón calcular.
5- Si se decea realizar otro calculo presionar el boton "Limpiar"
6- Si se desea volver al menu principal presionar el boton "Volver"
