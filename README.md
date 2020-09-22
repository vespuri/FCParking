# FCParking

Demonstração de REST API simulando um controle básico de estacionamento.

## Objetivo do Projeto

Esse projeto tem por objetivo demonstrar e exemplificar uma API REST em .net Core

### Tecnologias Utilizadas nesse Projeto

.NET CORE 3.1

SQL SERVER

REDIS para armazenamento de token em Cache

Autenticação com JWT

XUnit para teste Unitário (Utilizei 2 testes apenas para demonstração a implementação)

Moq para "Mockar" objetos

Serilog para registro de Log da Aplicação

Swashbuckle Swagger como expositor da API

### Rodando o Projeto

Primeiro passo é a configuração das strings de conexão no arquivo appsettings.json
Utilizei um banco de dados para a Aplicação e outro para a Autenticação.


```
Strings de Conexão
      BaseIdentity: String para a Autenticação
      App: String para a Aplicação
      ConexaoRedis: String para armazenamento do token em Cache
```  

      
```
Exemplo: Eu utilizei o banco local do SQL Server  
ConnectionStrings: {
    "BaseIdentity": "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=IdentityLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",  
    "App": "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=AppDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
    "ConexaoRedis": "localhost,port: 6379,password=Redis2020!"
  },

```

Como eu utilizei o Redis, é necessário apontar a string de conexão para um server Redis. Caso queira rodar o server localmente siga as instruções abaixo.

### Configurando o REDIS

Passo a Passo

Passo 1

Download redis

https://github.com/microsoftarchive/redis/releases/tag/win-3.2.100


Passo 2

Se baixar o arquivo zip e descompactar para C:\Redis

Passo 3

Start redis-server

Uma tela do prompt de comando irá abrir com a mensagem "The server is now ready to accept connections on port 6379"

Dica: Se o comando não funcionar no prompt de comando, será necessário adicionar um valor na Variavel de Ambiente "Path" com o caminho dos arquivos "C:\Redis"


### Feito isso o projeto deverá rodar sem problemas.


