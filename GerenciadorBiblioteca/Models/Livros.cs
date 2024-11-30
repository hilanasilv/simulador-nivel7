using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorBiblioteca.Models
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public int Edition { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
