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