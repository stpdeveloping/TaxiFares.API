# Taxi Fares API
[![GitHub version](https://img.shields.io/badge/version-1.0.0-green.svg)](https://github.com/stpdeveloping/TaxiFares.API)
> This microservice is part of Taxi Fares project. **TaxiFares API** receives fares from other microservice, called **Taxi Fares Reader Online** and saves them. Then these fares are fetched by **Taxi Fares Browser Client**

## Technologies
* **.NET 5**
* **Docker**

## Setup
1. Install the latest version of **Visual Studio**: <br/>https://visualstudio.microsoft.com/pl/vs/
2. Install **Windows Subsystem for Linux**: <br/>https://docs.microsoft.com/en-us/windows/wsl/install
3. Install **Docker Desktop for Windows**: <br/>https://docs.docker.com/desktop/windows/install/
1. Run solution in Visual Studio
2. Run **Swagger** (`http://localhost/swagger`) to see available API endpoints

## Status
Project is under active development

## Architecture
API is written in **DDD** approach combined with **CQRS** pattern. Unlike to Microsoft's examples the queries are also using **Entity Framework** like commands for better project management. <br/>API has integration tests, which are covering all functionalities. <br/>There are some development limitations due to using **SQLite** as database provider - let check documentation for details: <br/>https://docs.microsoft.com/pl-pl/ef/core/providers/sqlite/limitations

