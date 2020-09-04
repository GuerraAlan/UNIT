using System.Collections.Generic;

namespace Core.Models
{
    public class UndirectedGraph<T>
    {

        public ICollection<Vertex<T>> Vertices { get; set; }
    }
}