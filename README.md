<h1 align="center"> Desafio de Programação - Programa Warren Tech Academy </h1>

## Aplicação desenvolvida para avaliação do Programa Desafio Warren Tech Academy

Esta etapa do processo seletivo tem como objetivo avaliar o conhecimento de programação do aluno. Para tal, foram dados 3 desafios

### Os Desafios

#### Desafio 01
Alguns números inteiros positivos n possuem uma propriedade na qual a soma de n + reverso(n) resultam em números ímpares. Por exemplo, 36 + 63 = 99 e 409 + 904 = 1313. Considere que n ou reverso(n) não podem começar com 0. 
<p> Existem 120 números reversíveis abaixo de 1000.

Construa um algoritmo que mostre na tela todos os números n onde a soma de n + reverso(n) resultem em números ímpares que estão abaixo de 1 milhão.

#### Desafio 02
Um professor de programação, frustrado com a falta de disciplina de seus alunos, decide cancelar a aula se menos de x alunos estiverem presentes quando a aula for iniciada. 

O tempo de chegada varia entre: 
<p> Normal: tempoChegada <= 0 
<p> Atraso: tempoChegada > 0

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
A proposta é implementar uma Aplicação Console em C# para Windows utilizando o VSCode e o .NET Core (v.6.0.202).
Para isso, precisamos fazer o download e instalação destas ferramentas:
* VSCode (https://code.visualstudio.com/download)
* .NET SDK 6.0 (https://dotnet.microsoft.com/en-us/download). Após a instalação desta ferramenta, devemos entrar com o seguinte comando via terminal (pode ser o Prompt de Comando, GitBash ou o Terminal do VSCode):
```
dotnet --version
```
Algo como o código abaixo deverá surgir, indicando a instalação do .NET SDK com sucesso:

![image](https://user-images.githubusercontent.com/52115300/166314001-f92a3b0a-1fd7-4c90-bb36-253a0424c0d5.png)

Após, foi criado uma pasta para cada desafio: desafio1, desafio2 e desafio3. Acessando cada pasta pelo terminal (pode ser o Prompt de Comando, GitBash ou o Terminal do VSCode), foi executado o comando abaixo para que a Aplicação Console fosse criada. Esse comando, por si só, cria uma Aplicação Console com um "Hello, World!"
```
dotnet new console
```
Agora, após criada a apliação, podemos executá-la com o comando abaixo. 
```
dotnet run
```
![image](https://user-images.githubusercontent.com/52115300/166519480-558c2b3d-0c99-4e41-a2db-053f3230c4e6.png)

Após esses passos, deu-se inicio a implementação dos desafios

### Códigos fonte
  
#### Desafio 01
```
using System;
using System.Linq;

namespace Desafio1
{
    class Program
    {
        static void Main(string[] args)
        {
            //quantidade de numeros reversos
            int contador = 0;

            // numero máximo para fazer o cálculo. 
            // Alterar este valor caso desejar 
            int maximo = 1000000;

            // começamos de 12 pois:
            // - de 1 a 9 não há número inverso
            // - não usamos o 0 e 10 pois o número e seu reverso não podem começar com 0
            // - a soma do 11 com seu inverso não seria um número negativo            
            for (int i = 12; i <= maximo; i++)
            {
                // separa individualmente o numero atual e armazena num array
                var numeroSeparado = i.ToString().ToArray();

                // armazena somente o último número lido do numero separado
                var ultimoNumero = numeroSeparado.Last();

                // se o ultimo número for 0, não faz o calculo
                if (ultimoNumero != '0')
                {
                    // inverte o numero lido
                    string textoInvertido = new string(i.ToString().Reverse().ToArray());

                    // soma o numero lido com seu inverso     
                    var soma = int.Parse(textoInvertido) + i;

                    // se for numero impar, mostra.
                    if (soma % 2 != 0)
                    {
                        contador++;
                        Console.WriteLine($"Numero: {i} + Reverso: {textoInvertido} = Soma: {soma}");
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Total de números reversos até {maximo}: {contador}");
        }
    }
}
```
#### Desafio 02
```            
using System;

using System.Collections.Generic;
using System.Linq;

namespace Desafio2
{
    class Program
    {
        static void Main(string[] args)
        {
            // quantidade minima de alunos para iniciar a aula
            int x = 0;

            Console.Write("Quantidade mínima de alunos presentes para iniciar a aula" + 
                          "\n(SOMENTE NÚMEROS INTEIROS) " + 
                          "\n(99 para sair): ");
            try
            {
                x = int.Parse(Console.ReadLine());
                if (x == 99)
                {
                    return;
                }

                if (x <= 0)
                {
                    Console.Write("\nQuantidade deve ser maior que 0!");
                    Console.ReadKey();
                    return;
                }
            }
            catch
            {
                Console.WriteLine();
                Console.Write("Erro de conversão!");
                Console.WriteLine();
                return;
            }            

            Console.WriteLine("\nATENÇÃO PARA O TEMPO DE CHEGADA:" +
                          "\nMenor ou igual a zero: sem atraso. Exemplo: 0 ou 1" +
                          "\nMaior que 0 (zero): Atrasado. Exemplo: -1 " +
                          "\nSOMENTE NÚMEROS INTEIROS ");

            // armazena o tempo de chagada dos alunos
            List<int> tempoChegada = new List<int>();
            
            // valor do tempo informado
            int valorVetor = 0;

            // conta alunos dentro ou fora do horário
            int contaNormal = 0;
            int contaAtrasado = 0;

            Console.WriteLine();
            do
            {
                Console.Write("Tempo de chagada do aluno: (99 para sair): ");
                try
                {
                    valorVetor = int.Parse(Console.ReadLine());

                    if (valorVetor != 99)
                    {
                        //adiciona o tempo informado na lista
                        tempoChegada.Add(valorVetor);

                        if (valorVetor <= 0)
                        {
                            contaNormal++;
                        }
                        else
                        {
                            contaAtrasado++;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.Write("Erro de conversão! Somente números inteiros");
                    Console.WriteLine();
                }

            }
            while (valorVetor != 99);

            Console.WriteLine();
            // se o numero minimo de pessoas > quantidade que chegou
            if (x > tempoChegada.Count)
            {
                Console.WriteLine("Não há pessoas suficiente para iniciar a aula!");
                return;
            }
            else
            {
                string saida;
                // se minimo de pessoas = quantos chegaram
                if (x == tempoChegada.Count)
                {
                    saida = (contaAtrasado == 0) ? "Aula Normal" : "Aula Cancelada";
                }
                // se minimo de pessoas <> quantos chegaram
                else
                    saida = (contaNormal == x) ? "Aula Normal" : "Aula Cancelada";

                Console.WriteLine(saida);
            }
        }
    }
}
```                                        
#### Desafio 03
```
namespace Desafio3
{
    class Program
    {
        // armazena a menor quantidade atual de itens das combinações encontradas
        public static int valorMinimoSomaExata = 0;
        public static int valorMinimoSomaAproximada = 0;

        // armazena a menor quantidade antiga de itens das combinações encontradas 
        public static int menorAntigoSomaExata = 9999;
        public static int menorAntigoSomaAproximada = 9999;

        public static void Main(string[] args)

        {
            //valor da soma que se quer encontrar            
            Console.Write("SOMENTE NÚMEROS INTEIROS " +
                          "\nValor de N (99 para sair): ");

            int soma = 0;
            try
            {
                soma = int.Parse(Console.ReadLine());
                if (soma == 99)
                {
                    return;
                }

            }
            catch
            {
                Console.WriteLine();
                Console.Write("Erro de conversão!");
                Console.WriteLine();
                return;
            }

            //lista com os valores que serão usados para somar
            List<int> vetor = new List<int>();

            // numeros que serão usados para somar
            int valorVetor = 0;
            do
            {
                Console.Write("Preencha o vetor com números inteiros (99 para sair): ");

                try
                {
                    valorVetor = int.Parse(Console.ReadLine());
                    if (valorVetor != 99)
                    {
                        vetor.Add(valorVetor);
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.Write("Erro de conversão! Somente números inteiros");
                    Console.WriteLine();
                }

            }
            while (valorVetor != 99);

            resultados(vetor, soma);
        }

        private static void resultados(List<int> vetor, int soma)
        {
            if (vetor.Count != 0)
            {
                var result = new List<List<int>>();

                // COMBINAÇÃO: recebe as combinações encontradas e ordena em ordem crescente
                result = combinacao(vetor, soma).OrderBy(x => x.Count).ToList();

                // se o vetor está vazio, nenhuma combinação de soma existe
                Console.WriteLine();
                if (result.Count == 0)
                {
                    Console.WriteLine("Nenhuma combinação encontrada!");
                    return;
                }

                // lista com os menores numeros de itens para soma aproximada
                List<List<int>> minimoSomaAproximada = new List<List<int>>();

                // lista com os menores numeros de itens para soma exata
                List<List<int>> minimoSomaExata = new List<List<int>>();

                // seleciona somente vetores com o menor numero de itens e com soma aproximada
                minimoSomaAproximada = result.Where(x => x.Count == valorMinimoSomaAproximada && x.Sum() < soma).ToList();

                // seleciona somente vetores com o menor numero de itens e com soma exata
                minimoSomaExata = result.Where(x => x.Count == valorMinimoSomaExata && x.Sum() == soma).ToList();

                Console.WriteLine("Soma a ser encontrada: " + soma);

                Console.WriteLine();

                Console.WriteLine("Menor número de combinações encontradas com soma aproximada: ");
                if (minimoSomaAproximada.Count == 0)
                {
                    Console.WriteLine("NÃO FORAM ECONTRADAS COMBINAÇÕES");
                }
                else
                {
                    for (int i = 0; i < minimoSomaAproximada.Count; i++)
                    {
                        Console.WriteLine("[" + string.Join(", ", minimoSomaAproximada[i]) + "]");
                    }
                }

                Console.WriteLine("");

                Console.WriteLine("Menor número de combinações encontradas com soma exata:");
                if (minimoSomaExata.Count == 0)
                {
                    Console.WriteLine("NÃO FORAM ECONTRADAS COMBINAÇÕES");
                }
                else
                {
                    for (int i = 0; i < minimoSomaExata.Count; i++)
                    {
                        Console.WriteLine("[" + string.Join(", ", minimoSomaExata[i]) + "]");
                    }
                }

                Console.WriteLine();

                // mostra todas as combinações encontradas
                Console.WriteLine("Todas as combinações encontradas:");
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine("[" + string.Join(", ", result[i]) + "]");
                }
            }
        }

        public static List<List<int>> combinacao(List<int> array, int soma)
        {
            // ordena o array em ordem crescente
            array.Sort();

            //array para adicionar somente um unico elemento caso houver duplicados            
            var unico = new List<int>();

            // cria uma coleção não ordenada
            // e verifica se o elemento foi adicionado no array unico ou não            
            var hs = new HashSet<int>();
            for (int i = 0; i < array.Count; i++)
            {
                if (!hs.Contains(array[i]))
                {
                    hs.Add(array[i]);
                    unico.Add(array[i]);
                }
            }

            // copia o array unico para o array original
            // para armazenar a combinação unica
            array = unico;

            // armazena todas as combinações unicas         
            var vetor = new List<int>();
            var result = new List<List<int>>();

            // procura por combinações para atingir a soma
            procuraCombinacao(array, soma, result, vetor, 0);
            return result;
        }

        public static void procuraCombinacao(List<int> array, int soma,
            List<List<int>> resultadoSoma, List<int> vetor, int i)
        {
            if (soma < 0)
            {
                return;
            }

            // se a soma for exata, armazena a combinação na lista
            // e guarda a menor quantidade de itens
            if (soma == 0)
            {
                // adiciona o array encontrado na lista
                resultadoSoma.Add(new List<int>(vetor));
                // verifica o qual o array com a menor combinação
                // armazenando em valorMinimoSomaExata
                if (vetor.Count < menorAntigoSomaExata)
                {
                    valorMinimoSomaExata = vetor.Count;
                    menorAntigoSomaExata = valorMinimoSomaExata;
                }
                return;
            }

            // se a soma for aproximada, armazena a combinação na lista
            // e guarda a menor quantidade de itens 
            if (soma == 1)
            {
                // adiciona o array encontrado na lista
                resultadoSoma.Add(new List<int>(vetor));
                // verifica o qual o array com a menor combinação
                // armazenando em valorMinimoSomaAproximada
                if (vetor.Count < menorAntigoSomaAproximada)
                {
                    valorMinimoSomaAproximada = vetor.Count;
                    menorAntigoSomaAproximada = valorMinimoSomaAproximada;
                }
                return;
            }

            // recorrente para todos os elementos 
            // restantes que tem valor menor que a soma original
            while (i < array.Count && soma - array[i] >= 0)
            {
                // adiciona cada elemento do array ao vetor que contribui para a soma
                vetor.Add(array[i]);
                // recorrente para adicionar i ao vetor se contribui para a soma
                procuraCombinacao(array, soma - array[i], resultadoSoma, vetor, i);
                // move para o proximo elemento caso a soma 
                // dos elementos se tornar maior
                // ou igual a soma original
                i++;
                // remove o ultimo da lista de combinações
                // para adicionar o proximo elemento, basicamente retrocedendo
                vetor.RemoveAt(vetor.Count - 1);
            }
        }
    }
}
```            
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
  ![image](https://user-images.githubusercontent.com/52115300/166515902-a69c9bb4-c5e1-4e35-9479-6328993c9baf.png)

  - após entrar com o comando acima, a aplicação será executada

* pelo Prompt de Comando ou GitBash
  - acesse a pasta da aplicação e execute o mesmo comando usado anteriormente
  
  ![image](https://user-images.githubusercontent.com/52115300/166515038-1927592f-00cb-48da-8d8d-230fc3f7488b.png)
  
  ![image](https://user-images.githubusercontent.com/52115300/166515213-40628f55-3cee-43bf-a5b4-7f6c0508a5df.png)  
