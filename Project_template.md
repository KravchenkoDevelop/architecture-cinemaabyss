## Изучите [README.md](.\README.md) файл и структуру проекта.

я не могу понять почему при не изменяющемся коде тесты отваливаются в разных местах

# Задание 1


c4 диаграмма существующего решения


![c4](src\schemas\cinema_container_schema.jpg)




с4 диаграмма целевого решения с описанием процесса миграции


![c4](src\schemas\cinema_container_schema_target.jpg)


# Задание 2

### 1. Proxy

для ускорения разработки mvp был выбран [kong](src\microservices\proxy\kong.yml)

процесс миграции регулируется в разделе upstreams в файле конфигурации описанном ранее

![ev](src\screenshots\proxy.bmp)

### 2. Kafka

[events сервис](src\microservices\events) 

результаты теста

![ev](src\screenshots\events.bmp)

![alt text](src\screenshots\kafka.bmp)
# Задание 3
### CI/CD

- В файле [docker-build-push.yml](/.github/workflows/docker-build-push.yml) добавлены шаги сборки events-service и movies-service
  - proxy-service не добавлен, т.к. сборка для него не требуется - используется публичный образ "kong:3.8"
- api-tests и сборка включены для ветки "cinema", успешно проходят:
  - [сборка](https://github.com/Sugrob57/ITArch_Education_Sprint2/actions/runs/17923515915)
  - [тесты](https://github.com/Sugrob57/ITArch_Education_Sprint2/actions/runs/17923515913)

### Proxy в Kubernetes

- Доработаны файлы [event-service.yaml](/src/kubernetes/events-service.yaml) и [proxy-service.yaml](/src/kubernetes/proxy-service.yaml)
- Добавлен файл [kong-configmap.yaml](/src/kubernetes/kong-configmap.yaml) для настройки proxy-service


# Задание 4
- отредактирован файл [values.yaml](/src/kubernetes/helm/values.yaml)
- отредактирован файл [ingress.yaml](/src/kubernetes/helm/templates/ingress.yaml)
- подготовлен шаблон [events-service.yaml](/src/kubernetes/helm/templates/services/events-service.yaml)
- созданы файлы шаблона для proxy-service 
  - [proxy-service/deployment.yaml](/src/kubernetes/helm/templates/proxy-service/deployment.yaml)
  - [proxy-service/service.yaml](/src/kubernetes/helm/templates/proxy-service/service.yaml)
  - [proxy-service/configmap.yaml](/src/kubernetes/helm/templates/proxy-service/configmap.yaml)


запущенные поды в Helm

![alt text](src\screenshots\helm-result.png)