# Desafio Capgemini
### Aplicação desenvolvida para avaliação do Programa Desafio Academia Técnica Capgemini

## O Problema
A agência Divulga Tudo precisa de um programa para gerenciar os seus anúncios online. O objetivo dos anúncios faz parte de uma campanha nas redes sociais. O sistema de gerenciamento permitirá a gestão do anúncio e o rastreio dos resultados da campanha.

Este programa será composto de duas partes:
1ª Parte – Uma calculadora de alcance de anúncio online.
2ª Parte - Um sistema de cadastro de anúncios.

### 1ª Parte – Uma calculadora de alcance de anúncio online.
Criar um script em sua linguagem de programação preferida que receba o valor investido em reais e retorne uma projeção aproximada da quantidade máxima de pessoas que visualizarão o mesmo anúncio (considerando o anúncio original + os compartilhamentos)
```
using System;

namespace backend.servicos
{
     public class Calculadora
    {
        public double quantidadeAlcance = 0;
        public double quantidadeCliques = 0;
        public double quantidadeCompartilhamentos = 0;
        public double quantidadeNovosCompartilhamentos = 0;
        public int maximoCompartilhamentos = 0;
        
        public int CalculaMaximoCompartilhamento(double valor)
        {
            quantidadeAlcance = valor * 30;
            quantidadeCliques = quantidadeAlcance * 0.12;
            quantidadeCompartilhamentos = quantidadeCliques * 0.3;
            quantidadeNovosCompartilhamentos = quantidadeCompartilhamentos * 40;
            maximoCompartilhamentos = Convert.ToInt32(quantidadeNovosCompartilhamentos + 160);
            return maximoCompartilhamentos;
        }
    }
}
```

### 2ª Parte - Um sistema de cadastro de anúncios.
## Bases Utilizadas
Para cadastrar anuncios, serão usandas as bases Cliente e Anuncio. Estas bases armazenam e disponibilizam informações para o cadastro de anuncios. Cada base é usada como Classe para o desenvolvimento da aplicação.

### Cliente
```
Id int NOT NULL AUTO_INCREMENT
Nome longtext
```

### Anuncio
```
Id int NOT NULL AUTO_INCREMENT
Nome longtext
ClienteId int NOT NULL
DataInicio datetime NOT NULL
DataTermino datetime NOT NULL
InvestimentoDiario double NOT NULL
```

## Estrutura do Projeto
Aplicação principal, desenvolvida em Angular utilizando a IDE VSCode. Para o design das interfaces, foi utilizado Angular Material. O projeto foi desenvolvido com a seguinte estrutura:

### front-end (\frontend)
```
ng new frontend
```

### Estrutura do frontend
* components - para cada entidade, foi criado um componente para as ações Criar (create), Ler (read), Atualizar (update) e Apagar (delete)
```
ng generate component classe-acao
Ex.: ng generate component anuncio-read
```
 - views - Componente para "Apresentação" da entidade: opcão para um novo registro da entidade e a leitura (read) na mesma.
 - models - Modelo das Entidades utilizadas: Cliente e Anuncio
 - services - Para cada entidade, foram criados servicos para comunicação com a API: getAll, getById, Post, Put, Delete, entre outros
```
ng generate service entidade
Ex.: ng generate service anuncio
```
A comunicação com a API é feita através dos caminhos:
```
baseURL = `${environment.mainUrlAPI}entidade`
mainUrlAPI: 'http://localhost:5000/'
Ex.:
getAll(): Observable<Anuncio[]> {
    return this.http.get<Anuncio[]>(this.baseURL).pipe(
      map((obj) => obj),
      catchError((e) => this.errorHandler(e))
    );
  }
```
Rotas
```
http://localhost:4200/clientes
http://localhost:4200/anuncios

http://localhost:4200/entidade/create
http://localhost:4200/entidade/delete/id
http://localhost:4200/entidade/update/id

http://localhost:4200/relatorios
```

### back-end (\backend)
API desenvolvida em .Net Core para comunicação entre o Banco de Dados MySQL e a aplicação principal.
```
dotnet new webapi
```

### Estrutura do backend
 - data
    - DataContext: através dele podemos acessar os métodos create, read, update, delete e outros metodos de interação com o banco de dados.
    - IRepository: interface que contém a assinatura de metodos padrões (Add, Update, Delete, SaveChanges) e referentes a cada modelo.
    - Repositoy: classe que implementa a interface IRepository.
 - Controllers: responsável por responder as requisições em nossa API.
 - models: modelo da aplicação, que seriam as referências as tabelas que temos no banco de dados.
 - Migrations: guarda informações das migrações qua são feitas. Através do comando abaixo, EF Core "liga" as informações contidas na pasta models com as contidas no DbContext e cria um esquema da nossa base de dados: banco e tabelas, criando um histórico dentro desta pasta.
Com o próximo comando, o EF cria/atualiza o banco de dados a partir da migração.
```
dotnet ef migrations add Nome-Migracao
dotnet ef database update
```
Depois de pronta, para testar a API, foi utilizado o Postman. O objetivo é fazer requisições HTTP e avaliar se as repostas (retornos) foram dentro do esperado.

## Executando a aplicação no VSCode

Para que a aplicação seja executada, deve-se abrir o terminal no VSCode e executar os seguintes comandos:
(os próximos dois passos, devem ser executados apenas na primeira vez ou somente quando necessário)
- Passo 1: dentro de \backend: (executar somente uma vez, para a criação da base de dados)
```
dotnet ef database update
```
- Passo 2: dentro de \frontend: 
O próximo passo faz-se necessário somente caso necessite baixar/atualizar alguma dependencia do projeto. Antes da primeira vez que for rodar a aplicação, deve-se baixar todas as dependencias do projeto, executando o procedimento abaixo.
```
npm update
```
(os passos a seguir, devem ser executados SOMENTE após os passos anteriores)
- Passo 3: dentro de \backend:
Para rodar a API 
```
dotnet watch run
```
- Passo 4: dentro de \frontend:
Para rodar a aplicação principal
```
npm start
```
Se não apresentar nenhum erro, pode-se acessar a aplicação pelo navegador, através do endereço http://localhost:4200

## Retornos
Retorno das requisições feitas através do Postman

### Obter Clientes
- GetAll: obtem todos os Clientes cadastrados
```` json
url = http://localhost:5000/cliente
method = GET
{
    "id": 
    "nome":    
}
````
- GetById: obtem determinado Cliente pelo Id
```` json
url = http://localhost:5000/cliente/id
method = GET
{
    "id":
    "nome":
    "anuncios": [
        {
            "id":
            "nome":
            "clienteId":
            "dataInicio":
            "dataTermino":
            "investimentoDiario":
        }
    ]
}
````

### Obter Anuncios
- GetAll: obtem todos os Anuncios cadastrados
```` json
url = http://localhost:5000/anuncio
method = GET
{
        "id": 
        "nome":
        "clienteId":
        "dataInicio":
        "dataTermino":
        "investimentoDiario":
        "cliente": {
            "id":
            "nome": 
            "anuncios": []
        }
    },
````
- GetById: obtem determinado Anuncio pelo Id
```` json
url = http://localhost:5000/anuncio/id
method = GET
{
    "id": 
    "nome":
    "clienteId":
    "dataInicio":
    "dataTermino":
    "investimentoDiario":
    "cliente": null
}
````
- GetAllAnunciosByPesquisa: realiza uma pesquisa de Anuncios por Nome do Cliente, Data Inicio e Data Término
```` json
url = http://localhost:5000/anuncio/nome=nomePesquisado/di=dataInicial/df=dataFinal
method = GET
{
        "clienteId":
        "dataInicio":
        "dataTermino":
        "investimentoDiario":
        "cliente": {
            "id": 
            "nome": 
            "anuncios": []
        }
    },
````
- GetAllAnuncioByData: realiza uma pesquisa de Anuncios por Data Inicio e Data Término
```` json
url = http://localhost:5000/anuncio/di=dataInicial/df=dataFinal
method = GET
{
        "clienteId":
        "dataInicio":
        "dataTermino":
        "investimentoDiario":
        "cliente": {
            "id": 
            "nome": 
            "anuncios": []
        }
    },
````
