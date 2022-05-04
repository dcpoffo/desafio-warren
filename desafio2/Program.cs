using System;

using System.Collections.Generic;
using System.Linq;

namespace teste
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
