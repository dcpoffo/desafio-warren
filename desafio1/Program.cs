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
            int maximo = 1000;

            //começamos de 12 pois:
            // - de 1 a 9 não há número inverso
            // - não usamos o 0 e 10 pois o número e seu reverso não podem começar com 0
            // - a soma do 11 com seu inverso não seria um número negativo            
            for (int i = 12; i <= maximo; i++)
            {                
                var textoDividido = i.ToString().ToArray(); 

                // armazena o último número lido                            
                var ultimoNumero = textoDividido.Last();

                // inverte o numero lido
                string textoInvertido = new string(i.ToString().Reverse().ToArray()); 

                // se o ultimo número for 0, não faz o calculo
                if (ultimoNumero != '0')
                {               
                    // soma o numero lido com seu inverso     
                    var soma = int.Parse(textoInvertido) + i;

                    // se for numero impar, armazena.
                    if (soma % 2 != 0)
                    {
                        contador++;                 
                        Console.WriteLine($"Numero: {i} - Reverso: {textoInvertido} - Soma: {soma}");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Total de números reversos até {maximo}: {contador}");
        }
    }
}


