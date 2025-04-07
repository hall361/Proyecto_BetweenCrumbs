# BetweenCrumbs (Backend)

**BetweenCrumbs** es una plataforma web diseñada para la gestión y consulta de recetas culinarias complejas. Este proyecto está compuesto por tres partes principales: el frontend, el backend y la base de datos. Este repositorio corresponde exclusivamente al **backend**, desarrollado en .NET 8.0, encargado de gestionar la lógica de negocio y las funcionalidades principales de la plataforma.

## Descripción del Proyecto

El objetivo de **BetweenCrumbs** es proporcionar una solución integral para los amantes de la cocina, permitiendo explorar, gestionar y compartir recetas culinarias avanzadas. Este backend expone una API RESTful que interactúa con el frontend y la base de datos para ofrecer una experiencia fluida y eficiente.

## Componentes del Proyecto

El proyecto completo está compuesto por:

1. **Frontend**: Desarrollado en Visual C#, encargado de la interfaz de usuario.
2. **Backend**: Este repositorio, desarrollado en .NET 8.0, que gestiona la lógica de negocio y expone la API RESTful.
3. **Base de Datos**: Sistema de almacenamiento de datos, configurado para interactuar con el backend.

## Integrantes del Proyecto

Este proyecto fue desarrollado por los siguientes integrantes:

- **Jaime Acevedo Porras** - Cod. 100306577
- **Martin Alonso Cortes Herrera** - Cod. 100382794
- **Harold Garzón Bonilla** - Cod. 100274901
- **Juan Pablo Motato Restrepo** - Cod. 100345907
- **Héctor Aníbal López López** - Cod. 100308773
- **Edwar Enrique Ospina Bermúdez** - Cod. 100290792
- **Camilo Pasos Luna** - Cod. 100375632

**Institución:** Politécnico Grancolombiano Institución Universitaria  
**Curso:** Primer Bloque Teórico-Práctico - Virtual/Arquitectura de Software - [Grupo B01] - Subgrupo 2  
**Tutora Virtual:** Natalia Martinez Rojas  
**Año:** 2025

## Estructura del Backend

El backend está organizado en las siguientes capas:

- **BC.Application**: Contiene la lógica de negocio y los servicios.
- **BC.Models**: Define los modelos de datos y DTOs utilizados en la aplicación.
- **BC.Repositories**: Implementa la capa de acceso a datos y utilidades relacionadas.
- **BetweenCrumbsAPI**: Contiene la configuración principal de la API, controladores y archivos de configuración.

## Requisitos Previos

Antes de ejecutar el backend, asegúrate de tener instalados los siguientes componentes:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o cualquier IDE compatible con .NET
- [SQL Server](https://www.microsoft.com/sql-server) (si la base de datos está configurada para usar SQL Server)

## Configuración

1. Clona este repositorio en tu máquina local:
   ```bash
   git clone <URL_DEL_REPOSITORIO>