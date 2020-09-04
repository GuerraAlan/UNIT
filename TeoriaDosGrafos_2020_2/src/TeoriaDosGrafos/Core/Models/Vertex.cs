using System.Collections.Generic;

namespace Core.Models
{
    public class Vertex<T>
    {
        public ICollection<Vertex<T>> Neighbors { get; set; }
        public T Value { get; set; }
        public bool Visited { get; set; }
    }
}