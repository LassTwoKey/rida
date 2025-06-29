## Магазин одежды 🧺 Rida Store

Магазин для покупки супер классной одежды самых креативных и превосходных личностей

### Что используется:

- C# ASP .NET Core Web Api
- Nextjs
- Docker
- Postgres
- Nginx

### Установка

**1. Устанавливаем Docker Engine или Docker Desktop:**

Пример для VPS машины на Ubuntu 22.04:

```bash
sudo apt update

sudo apt install curl software-properties-common ca-certificates apt-transport-https -y

wget -O- https://download.docker.com/linux/ubuntu/gpg | gpg --dearmor | sudo tee /etc/apt/keyrings/docker.gpg > /dev/null

echo "deb [arch=amd64 signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu jammy stable"| sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

sudo apt update
```

Убедимся, что инсталляция будет осуществлена из нужного нам репозитория (ubuntu-jammy)

```
apt-cache policy docker-ce
```

```
sudo apt install docker-ce -y
```

Убедимся в успешности установки, проверив статус докера в системе:

```
sudo systemctl status docker
```

**2. Установка Git:**

```
sudo apt-get install git
```

Убедимся в успешности установки, проверив версию git:

```
git --version
```

**3. Установка Docker Compose:**

```
! Latest-версия Docker Compose для установки на Ubuntu тут https://github.com/docker/compose/releases
sudo curl -L "https://github.com/docker/compose/releases/download/v2.37.3/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose

sudo chmod +x /usr/local/bin/docker-compose

sudo apt-get install docker-compose
```

**4. Клонирование проекта:**

```
git clone https://github.com/LassTwoKey/rida.git
```

**5. Меняем файл .env под себя:**

Посмотреть содержимое `.env`. Для сохранения: **Ctrl+O**, затем **Enter**, а для выхода: **Ctrl+X**

```
sudo apt update
sudo apt install nano
sudo nano .env
```

```
# Example
POSTGRES_HOST=postgres
POSTGRES_DB=RidaDb
POSTGRES_USER=userok
POSTGRES_PASSWORD=123

POSTGRES_PORT=5432
API_PORT=8080
NEXT_JS_PORT=3000
```

**6. Настройка nginx:**

Посмотреть содержимое `.env`. Поменять `server_name` на свой домен или ip. Для сохранения: **Ctrl+O**, затем **Enter**, а для выхода: **Ctrl+X**
```
cd nginx/conf.d
sudo nano default.conf
```

**7. Запуск Docker Compose:**

Пересборка и запуск (при изменении конфигурации)

```
docker-compose up -d --build
```

**Удаление** контейнеров и volumes (**полная очистка**)

```
docker-compose down -v
```

**8. Миграции:**

Миграция для апи при работе со слоем бд

```
dotnet ef migrations add initial -s .\src\App.Api\ -p .\src\App.DataAccess\
```

Применение миграций

```
dotnet ef database update -s .\src\App.Api\ -p .\src\App.DataAccess\
```

Для обновления миграций. Надо **остановить** контейнеры и **запустить** обратно.

```
docker-compose down

dotnet ef migrations add UpdateSchema -s .\src\App.Api\ -p .\src\App.DataAccess\
dotnet ef database update -s .\src\App.Api\ -p .\src\App.DataAccess\

docker-compose up -d --build
```
