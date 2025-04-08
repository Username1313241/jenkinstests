# Базовый образ Jenkins LTS
FROM jenkins/jenkins:lts

# Переключаемся на root для установки зависимостей
USER root

# 📦 Установка системных зависимостей
RUN apt-get update && apt-get install -y \
    wget \
    curl \
    unzip \
    software-properties-common \
    apt-transport-https

# 🧰 Установка .NET SDK 8.0
RUN wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb \
    && dpkg -i packages-microsoft-prod.deb \
    && rm packages-microsoft-prod.deb \
    && apt-get update \
    && apt-get install -y dotnet-sdk-8.0

# 📊 Установка Allure 2.27.0
RUN curl -fLo allure.zip https://repo.maven.apache.org/maven2/io/qameta/allure/allure-commandline/2.27.0/allure-commandline-2.27.0.zip \
    && echo "✅ Allure ZIP downloaded" \
    && unzip -l allure.zip \
    && unzip allure.zip -d /opt/ \
    && mv /opt/allure-2.27.0 /opt/allure \
    && ln -s /opt/allure/bin/allure /usr/bin/allure \
    && rm -rf allure.zip

# 🧹 Очистка кэша apt
RUN apt-get clean

# Возврат пользователя Jenkins
USER jenkins

# Рабочая директория Jenkins
WORKDIR /var/jenkins_home