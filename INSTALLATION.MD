# Инструкция по установке

## Docker

- Компилируем образ Docker

<code>docker image build -t mvc-service .</code>

- Сохраняем образ в tar архив

<code>docker save --output mvc-service.tsr mvc-service</code>

- Загружаем образ на сервер и загружаем его

<code>docker load --input mvc-service.tar</code>

- Проверим образ

<code>docker images</code>

Среди образов должен быть mvc-service

- Запуск через Docker Compose

<code>sudo docker-compose -p serv up -d</code>

- Остановить сервер

<code>sudo docker-compose -p serv down</code>

## Стандартный запуск в .Net

<code>dotnet publish</code>