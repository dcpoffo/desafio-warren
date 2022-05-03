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

            // numeros que serão usados para somar
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
                result = combinacao(vetor, soma).OrderBy(x => x.Count).ToList();

                // se o vetor está vazio, nenhuma combinação de soma existe
                Console.WriteLine();
                if (result.Count == 0)
                {
                    Console.WriteLine("Nenhuma combinação encontrada!");
                    return;
                }

                Console.WriteLine(soma);

                Console.WriteLine();

                //Combinações mínimas encontradas
                // Lista para armazenar os vetores com o minimo de itens                
                List<List<int>> minimo = new List<List<int>>();

                // adiciona somente vetores com o numero minimo de itens
                minimo = result.Where(x => x.Count == valorMinimo).ToList();
                
                Console.WriteLine("Menor número de combinações encontradas:");
                for (int i = 0; i < minimo.Count; i++)
                {
                    Console.Write("[");
                    Console.WriteLine(string.Join(", ", minimo[i]) + "]");
                }

                Console.WriteLine();
                
                // mostra todas as combinações encontradas
                Console.WriteLine("Combinações encontradas:");
                for (int i = 0; i < result.Count; i++)
                {
                    Console.Write("[");
                    Console.WriteLine(string.Join(", ", result[i]) + "]");
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
            List<List<int>> result, List<int> vetor, int i)
        {                       
            if (soma < 0)
            {
                return;
            }
            // se fechou a soma
            if (soma == 0)
            {                
                // adiciona o array encontrado na lista
                result.Add(new List<int>(vetor));
                // verifica o qual o array com a menor combinação
                // armazenando em valorMinimo
                if (vetor.Count < menorAntigo)
                {
                    valorMinimo = vetor.Count;
                    menorAntigo = valorMinimo;
                }

                return;
            }
            
            // recorrente para todos os elementos 
            // restantes que tem valor menor que a soma original
            while (i < array.Count && soma - array[i] >= 0)
            {                
                // adiciona cada elemento do array ao vetor iniciado por i
                // que contribui para a soma
                vetor.Add(array[i]);                
                // recorrente para adicionar array[i] ao vetor se contribui para a soma
                procuraCombinacao(array, soma - array[i], result, vetor, i);                
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