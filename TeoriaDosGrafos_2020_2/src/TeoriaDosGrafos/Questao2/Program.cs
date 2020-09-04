using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Questao2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void BuscaProfundidade<T>(Vertex<T> verticeInicial)
        {
            var pilha = new Stack<Vertex<T>>();
            verticeInicial.Visited = true;
            pilha.Push(verticeInicial);

            var vertice = pilha.Peek();
            do
            {
                vertice = vertice.Neighbors.FirstOrDefault(vizinho => !vizinho.Visited);

                if (vertice != null)
                {
                    vertice.Visited = true;
                    pilha.Push(vertice);
                }
                else
                {
                    vertice = pilha.Pop();
                }
            } while (pilha.Any());
        }

        static int BuscaLargura<T>(UndirectedGraph<T> grafo, Vertex<T> verticeInicial = null)
        {
            verticeInicial ??= grafo.Vertices.First();
            var conexosCount = 1;
            var nivelCount = 0;
            var fila = new Queue<Vertex<T>>();
            verticeInicial.Visited = true;
            fila.Enqueue(verticeInicial);
            var ordenado = new Dictionary<int, ICollection<Vertex<T>>>();
            
            do
            {
                var vertice = fila.Dequeue();
                
                ordenado.Add(nivelCount++, new List<Vertex<T>>());
                ordenado[nivelCount].Add(vertice);

                foreach (var vertex in vertice.Neighbors.Where(v => !v.Visited))
                {
                    vertex.Visited = true;
                    fila.Enqueue(vertex);
                    conexosCount++;
                }
            } while (fila.Any());

            for (var i = 0; i < nivelCount; i++)
            {
                Console.WriteLine($"{i}: ");
                foreach (var vertex in ordenado[i])
                {
                    Console.Write($"{vertex.Value.ToString()}\t");
                }
                Console.WriteLine();
            }
            
            return grafo.Vertices.Count != conexosCount ? conexosCount : 0;
        }
    }
}