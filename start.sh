#! /bin/bash

dotnet restore

dotnet publish ChildrensGame.Api -c Release -o ./dist

dotnet publish ChildrensGame.Cli -c Release -o ./dist

docker-compose down --rmi all

docker-compose up --build
