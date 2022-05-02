# Desafio de Programação - Programa Warren Tech Academy
## Aplicação desenvolvida para avaliação do Programa Desafio Warren Tech Academy

Esta etapa do processo seletivo tem como objetivo avaliar o conhecimento de programação do aluno. Para tal, foram dados 3 desafios, descritos logo abaixo.

A proposta é implementar uma Aplicação Console para Windows utilizando o VSCode e o .NET Core (v.6.0.202).
Para isso, precisamos fazer o download e instalação destas ferramentas:
* VSCode (https://code.visualstudio.com/download)
* .NET SDK 6.0 (https://dotnet.microsoft.com/en-us/download). Após a instalação desta ferramenta, devemos entrar com o seguinte comando via terminal(*):
```
dotnet --version
```
Algo como o código abaixo deverá surgir, indicando a instalação do .NET SDK com sucesso:

![image](https://user-images.githubusercontent.com/52115300/166314001-f92a3b0a-1fd7-4c90-bb36-253a0424c0d5.png)

Após, foi criado uma pasta para cada desafio: desafio1, desafio2 e desafio3. Dentro de cada pasta, foi executado o seguinte comando para que a Aplicação Console fosse criada: 
```
dotnet new console
```
Algo como o código abaixo deverá surgir:

![image](https://user-images.githubusercontent.com/52115300/166315239-3e6ff282-785e-4345-b96f-aaf474cada76.png)

Após esses passos, a aplicação já pôde ser desenvolvida.

(*) pode ser o CMD, GitBash ou o Terminal do VSCode.

### Os Desafios

#### Desafio 01
Alguns números inteiros positivos n possuem uma propriedade na qual a soma de n + reverso(n) resultam em números ímpares. Por exemplo, 36 + 63 = 99 e 409 + 904 = 1313. Considere que n ou reverso(n) não podem começar com 0.
Existem 120 números reversíveis abaixo de 1000.
Construa um algoritmo que mostre na tela todos os números n onde a soma de n + reverso(n) resultem em números ímpares que estão abaixo de 1 milhão.

#### Desafio 02

#### Desafio 03
