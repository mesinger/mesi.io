@echo off
docker-compose -f docker-compose-frontend.yml down
docker-compose -f docker-compose-api.yml down