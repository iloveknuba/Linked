# Використовуємо базовий образ з підтримкою .NET Core
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Встановлюємо робочу директорію
WORKDIR /app

# Копіюємо файли проекту у робочу директорію контейнера
COPY . .

# Встановлюємо Chrome та ChromeDriver
RUN apt-get update && apt-get install -y chromium && apt-get clean
ENV CHROME_BIN /usr/bin/chromium-browser
ENV CHROME_DRIVER /usr/bin/chromedriver

# Встановлюємо залежності та компілюємо програму
RUN dotnet restore
RUN dotnet build -c Release -o out

# Виконуємо програму при старті контейнера
ENTRYPOINT ["dotnet", "out/YourProjectName.dll"]