@echo off
docker-compose -f docker-compose-frontend.yml up -d --build
docker-compose -f docker-compose-api.yml up -d --build