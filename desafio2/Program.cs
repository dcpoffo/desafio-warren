using System;

using System.Collections.Generic;
using System.Linq;

namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;

            Console.Write("Quantidade mínima de alunos presentes para iniciar a aula (99 para sair): ");
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

            List<int> listaTempoChagada = new List<int>();

            Console.WriteLine("\nATENÇÃO PARA O TEMPO DE CHEGADA:" +
                          "\nMenor ou igual a zero: Sem atraso. Exemplo: 0 ou 2" +
                          "\nMaior que 0 (zero): Atrasado. Exemplo: -1 " +
                          "\nSOMENTE NÚMEROS INTEIROS ");

            List<int> tempoChegada = new List<int>();
            int valorVetor = 0;
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
            // minimo de pessoas > quantidade que chegou
            if (x > tempoChegada.Count)
            {
                Console.WriteLine("Não há pessoas suficiente para iniciar a aula!");
                return;
            }
            else
            {
                string saida;
                // minimo de pessoas e quantos chegaram é igual
                if (x == tempoChegada.Count)
                {
                    saida = (contaAtrasado == 0) ? "Aula Normal" : "Aula Cancelada";
                }
                // minimo de pessoas e quantos chegaram é diferente
                else
                    saida = (contaNormal == x) ? "Aula Normal" : "Aula Cancelada";

                Console.WriteLine(saida);
            }
        }
    }
}
