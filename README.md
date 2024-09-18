# 🔥 Projeto de Teste WebTarefas 
Bem-vindo(a) ao **WebTarefas**! Aqui você poderá utilizar um CRUD simples, que faz uso de uma API .Net Core para operações simples!
O Projeto foi estruturado da seguinte forma:

- WebTarefas/
-- WebTarefas.csproj
- WebTarefas.Domain/
-- WebTarefas.Domain.csproj
- WebTarefas.Infra/
-- WebTarefas.Infra.csproj
- WebTarefas.Service/
-- WebTarefas.Service.csproj
- Dockerfile


## 🚀 Configurando o Docker do WebTarefas

Para testar o container do WebTarefas, siga estas etapas, na pasta raiz onde se encontra o arquivo **docker-compose.yml** :
```
docker build -t webtarefas .
```
Em seguida:
```
docker run -d -p 8080:8080 -p 8081:8081 webtarefas
```
Após isso, será possível navegar prontamente pela URL (exemplo):

```
http://localhost:8080/swagger/index.html
```


## 💻 Pré-requisitos

Para melhor compatibilidade, utilizei a última versão disponível do **.NET Core**

- O pacote utilizado para o container é da versão 8.0 `mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809`


  
## ☕ Características
- Separação da solução em camadas
- Uso do Docker
- Validações básicas
- Uso de Banco de dados **In Memory**
- Testes Unitarios utilizando xUnit
- Swagger para documentação/visualização/teste da API

