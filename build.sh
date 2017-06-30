#! /bin/bash

dotnet restore

dotnet publish ChildrensGame.Api -c Release -o ./dist

dotnet publish ChildrensGame.Cli -c Release -o ./dist

docker stop -t 15 childrensgame_container_api
docker stop -t 15 childrensgame_container_cli

docker rm childrensgame_container_api
docker rm childrensgame_container_cli

docker rmi childrensgame_api
docker rmi childrensgame_cli

docker-compose build
