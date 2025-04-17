@echo off
echo Starting the Blogg App...

:: Start frontend (Vue.js)
start cmd /k "cd client && npm install && npm run serve"

:: Start backend (ASP.NET Web API)
start cmd /k "cd server && dotnet restore && dotnet run"