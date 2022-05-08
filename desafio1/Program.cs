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
            // - não usamos o 10 pois seu reverso começa com 0
            // - a soma do 11 com seu inverso não será um número negativo            
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


