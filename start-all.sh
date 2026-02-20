#!/bin/bash
trap 'kill 0' SIGINT

echo "Starting Backend on http://localhost:5149 ..."
cd TestWebAppNet10.API
dotnet run &

echo "Starting Frontend on http://localhost:4200 ..."
cd ../Frontend
npm start &

wait
