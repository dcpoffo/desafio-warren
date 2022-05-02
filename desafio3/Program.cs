namespace Desafio3
{
	class Program
	{
        // armazena a menor quantidade atual de itens das combinações encontradas
        public static int valorMinimo = 0;
        // armazena a menor quantidade antiga de itens das combinações encontradas 
        public static int menorAntigo = 9999;
        public static void Main(string[] args)

        {
            //valor da soma que se quer encontrar
            Console.Write("Valor de N: ");
            int soma = int.Parse(Console.ReadLine());

            //lista com os valores que serão usados para somar
            List<int> vetor = new List<int>();

            int valorVetor = 0;
            do
            {
                Console.Write("Preencha o vetor com números inteiros (99 para sair): ");

                valorVetor = int.Parse(Console.ReadLine());
                if (valorVetor != 99)
                {
                    vetor.Add(valorVetor);
                }
            }
            while (valorVetor != 99);

            if (vetor.Count != 0)
            {
                var result = new List<List<int>>();

                //SOMA COMBINAÇÃO: recebe a combinações encontradas e ordena em ordem crescente
                result = combinationSum(vetor, soma).OrderBy(x => x.Count).ToList();

                // se o vetor está vazio, nenhuma combinação de soma existe
                Console.WriteLine();
                if (result.Count == 0)
                {
                    Console.WriteLine("Nenhuma combinação encontrada!");
                    return;
                }

                
                Console.WriteLine("Combinações encontradas:");
                for (int i = 0; i < result.Count; i++)
                {
                    Console.Write("[");
                    Console.WriteLine(string.Join(", ", result[i]) + "]");
                }

                Console.WriteLine();

                //Combinações mínimas encontradas
                List<List<int>> minimo = new List<List<int>>();
                minimo = result.Where(x => x.Count == valorMinimo).ToList();
                Console.WriteLine("Menor número de combinações encontradas:");
                for (int i = 0; i < minimo.Count; i++)
                {
                    Console.Write("[");
                    Console.WriteLine(string.Join(", ", minimo[i]) + "]");
                }

            }
        }

        public static List<List<int>> combinationSum(List<int> arr, int sum)
        {
            // sort input array 
            arr.Sort();
            // remove duplicates        
            // create an array to add all the unique elements to it
            var unico = new List<int>();
            // create a set to check whether an element
            // has been added to unique array or not
            var hs = new HashSet<int>();

            for (int i = 0; i < arr.Count; i++)
            {
                //if (hs.Contains(arr[i]) == false)
                if (!hs.Contains(arr[i]))
                {
                    hs.Add(arr[i]);
                    unico.Add(arr[i]);
                }
            }
            // copy the unique array back to original array
            //arr = unico;
            // to store a unique combination
            var vec = new List<int>();
            // stores all the unique combinations
            var result = new List<List<int>>();

            findCombination(arr, sum, result, vec, 0);
            return result;
        }

        public static void findCombination(List<int> arr, int sum,
            List<List<int>> result, List<int> vec, int i)
        {
            // sum of elements in vec becomes greater than original sum
            if (sum < 0)
            {
                return;
            }
            // sum of elements in vec is exactly equal to original sum
            if (sum == 0)
            {
                // add that particular combination to result
                //adiciona O ENCONTRADO na lista
                result.Add(new List<int>(vec));
                if (vec.Count < menorAntigo)
                {
                    valorMinimo = vec.Count;
                    menorAntigo = valorMinimo;
                }

                return;
            }
            // recur for all remaining elements that
            // have value smaller than original sum.
            while (i < arr.Count && sum - arr[i] >= 0)
            {
                // add every element of the array to the vec starting from i
                // that adds/contributes to 'sum'
                vec.Add(arr[i]);
                // recur to adding arr[i] to vec
                // if it contributes to 'sum'
                findCombination(arr, sum - arr[i], result, vec, i);
                // move to next element in case
                // sum of elements becomes greater than
                // or equal to the required sum
                i++;
                // remove the last number from the combination list
                // to add next element(basically backtracking)
                vec.RemoveAt(vec.Count - 1);
            }
        }
    }
}