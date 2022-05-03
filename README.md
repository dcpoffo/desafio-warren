# Desafio de Programação - Programa Warren Tech Academy
## Aplicação desenvolvida para avaliação do Programa Desafio Warren Tech Academy

Esta etapa do processo seletivo tem como objetivo avaliar o conhecimento de programação do aluno. Para tal, foram dados 3 desafios

### Os Desafios

#### Desafio 01
Alguns números inteiros positivos n possuem uma propriedade na qual a soma de n + reverso(n) resultam em números ímpares. Por exemplo, 36 + 63 = 99 e 409 + 904 = 1313. Considere que n ou reverso(n) não podem começar com 0.
Existem 120 números reversíveis abaixo de 1000.

Construa um algoritmo que mostre na tela todos os números n onde a soma de n + reverso(n) resultem em números ímpares que estão abaixo de 1 milhão.

#### Desafio 02
Um professor de programação, frustrado com a falta de disciplina de seus alunos, decidi cancelar a aula se menos de x alunos estiverem presentes quando a aula for iniciada. O tempo de chegada varia entre: Normal: tempoChegada <= 0 / Atraso: tempoChegada > 0

Construa um algoritmo que dado o tempo de chegada de cada aluno e o limite x de alunos presentes, determina se a classe vai ser cancelada ou não ("Aula cancelada” ou “Aula normal”).

Exemplo:
Entrada de dados:
x = 3
tempoChegada = [-2, -1, 0, 1, 2]

Saída de dados:
Aula normal.

Explicação:
Os três primeiros alunos chegaram no horário. Os dois últimos estavam atrasados. O limite é de três alunos, portanto a aula não será cancelada.

#### Desafio 03
Dado um vetor de números e um número n. Determine a soma com o menor número de elementos entre os números do vetor mais próxima de n e também mostre os elementos que compõem a soma. Para criar a soma, utilize qualquer elemento do vetor uma ou mais vezes.

Exemplo:
Entrada de dados:
N = 10
V = [2, 3, 4]

Saída de dados:
10
[2, 4, 4]
[3, 3, 4]

Explicação:
Se N = 10 e V = [2, 3, 4] você pode utilizar as seguintes soma: [2, 2, 2, 2, 2], [2, 2, 3, 3], [2, 4, 4] ou [3, 3, 4]. Como a quantidade de elementos em [2, 4, 4] e [3, 3, 4] é igual, os dois conjuntos devem ser mostrados.


### Proposta, ferramentas utilizadas e configurações
A proposta é implementar uma Aplicação Console para Windows utilizando o VSCode e o .NET Core (v.6.0.202).
Para isso, precisamos fazer o download e instalação destas ferramentas:
* VSCode (https://code.visualstudio.com/download)
* .NET SDK 6.0 (https://dotnet.microsoft.com/en-us/download). Após a instalação desta ferramenta, devemos entrar com o seguinte comando via terminal (pode ser o Prompt de Comando, GitBash ou o Terminal do VSCode):
```
dotnet --version
```
Algo como o código abaixo deverá surgir, indicando a instalação do .NET SDK com sucesso:

![image](https://user-images.githubusercontent.com/52115300/166314001-f92a3b0a-1fd7-4c90-bb36-253a0424c0d5.png)

Após, foi criado uma pasta para cada desafio: desafio1, desafio2 e desafio3. Acessando cara pasta pelo terminal (pode ser o Prompt de Comando, GitBash ou o Terminal do VSCode), foi executado o seguinte comando para que a Aplicação Console fosse criada: 
```
dotnet new console
```
Algo como o código abaixo deverá surgir:

![image](https://user-images.githubusercontent.com/52115300/166315239-3e6ff282-785e-4345-b96f-aaf474cada76.png)

Após esses passos, deu-se inicio a implementação dos desafios

### Executando as aplicações
Podemos executar as aplicações de duas maneiras:
* pelo VSCode
  - Abra o VSCode e vá em Abrir Pasta
  
  ![image](https://user-images.githubusercontent.com/52115300/166511130-69be74b9-95ca-44fd-b031-ab58a0f70a84.png)
  - Selecione a pasta que deseja executar a aplicação e clique em Selecionar pasta
  
  ![image](https://user-images.githubusercontent.com/52115300/166511732-3adb224a-cb81-4023-80d9-e203ff574b0d.png)
  
  - Vá em Terminal, Novo Terminal
  
  ![image](https://user-images.githubusercontent.com/52115300/166512448-a3b9fb1a-cb86-49c1-a068-1d8a4cf96ccd.png)
  
  - No Terminal aberto logo abaixo, execute o comando
  ```
  dotnet run
  ```
  - ![image](https://user-images.githubusercontent.com/52115300/166515902-a69c9bb4-c5e1-4e35-9479-6328993c9baf.png)

  - após entrar com o comando acima, a aplicação será executada

* pelo Prompt de Comando ou GitBash
  - acesse a pasta da aplicação e execute o mesmo comando usado anteriormente
  
  ![image](https://user-images.githubusercontent.com/52115300/166515038-1927592f-00cb-48da-8d8d-230fc3f7488b.png)
  
  ![image](https://user-images.githubusercontent.com/52115300/166515213-40628f55-3cee-43bf-a5b4-7f6c0508a5df.png)  
 

### Os Desafios

#### Desafio 01
Alguns números inteiros positivos n possuem uma propriedade na qual a soma de n + reverso(n) resultam em números ímpares. Por exemplo, 36 + 63 = 99 e 409 + 904 = 1313. Considere que n ou reverso(n) não podem começar com 0.
Existem 120 números reversíveis abaixo de 1000.

Construa um algoritmo que mostre na tela todos os números n onde a soma de n + reverso(n) resultem em números ímpares que estão abaixo de 1 milhão.

#### Desafio 02
Um professor de programação, frustrado com a falta de disciplina de seus alunos, decidi cancelar a aula se menos de x alunos estiverem presentes quando a aula for iniciada. O tempo de chegada varia entre: Normal: tempoChegada <= 0 / Atraso: tempoChegada > 0

Construa um algoritmo que dado o tempo de chegada de cada aluno e o limite x de alunos presentes, determina se a classe vai ser cancelada ou não ("Aula cancelada” ou “Aula normal”).

Exemplo:
Entrada de dados:
x = 3
tempoChegada = [-2, -1, 0, 1, 2]

Saída de dados:
Aula normal.

Explicação:
Os três primeiros alunos chegaram no horário. Os dois últimos estavam atrasados. O limite é de três alunos, portanto a aula não será cancelada.

#### Desafio 03
Dado um vetor de números e um número n. Determine a soma com o menor número de elementos entre os números do vetor mais próxima de n e também mostre os elementos que compõem a soma. Para criar a soma, utilize qualquer elemento do vetor uma ou mais vezes.

Exemplo:
Entrada de dados:
N = 10
V = [2, 3, 4]

Saída de dados:
10
[2, 4, 4]
[3, 3, 4]

Explicação:
Se N = 10 e V = [2, 3, 4] você pode utilizar as seguintes soma: [2, 2, 2, 2, 2], [2, 2, 3, 3], [2, 4, 4] ou [3, 3, 4]. Como a quantidade de elementos em [2, 4, 4] e [3, 3, 4] é igual, os dois conjuntos devem ser mostrados.
