# TravelRoute

## Sobre a solução

Para implementar a solução calculando o menor custo de rota foi utilizado o Algoritmo de Dijkstra, que calcula o menor caminho possível dentro de todos os caminhos  dentro de um grafo, que no caso desse projeto, são aeroportos  

## Requisitos para a API funcionar
Para rodar esta API é necessário ter o SQL Server Express instalado na máquina, além do runtime do .NET 5, que vem incluso com o SDK do .NET 5

A versão do .NET utilizada nesse projeto foi a 5.0.401

## Após instalar o SQL Server Express

Utilizar o script de criação de banco de dados que está aqui com o nome travel_database.sql

OBS: Se necessário alterar a string de conexão no arquivo appsettings.json dentro do projeto TravelRoute.API
