using GerenciadorBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GerenciadorBiblioteca.Data
{
    public class BibliotecaData
    {
        private readonly string filePath = "LibraryData.xml";

        public List<Book> LoadBooks()
        {
            if (!File.Exists(filePath))
                return new List<Book>();

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(List<Book>));
                return (List<Book>)serializer.Deserialize(stream);
            }
        }

        public void SeedData()
        {
            if (!File.Exists(filePath))
            {
                var initialBooks = new List<Book>
        {
            new Book
            {
                Title = "Torto Arado",
                Author = "Itamar Vieira",
                ISBN = "9781234567897",
                Pages = 140,
                Edition = 1,
                IsAvailable = true
            },
            new Book
            {
                Title = "Cem anos de solidão",
                Author = "Gabriel Garcia",
                ISBN = "9781234567896",
                Pages = 320,
                Edition = 5,
                IsAvailable = true
            },
            new Book
            {
                Title = "Vigiar e Punir",
                Author = "Michel Foucault",
                ISBN = "9781234567895",
                Pages = 135,
                Edition = 10,
                IsAvailable = false
            }
        };

                SaveBooks(initialBooks);
            }
        }


        public void SaveBooks(List<Book> books)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<Book>));
                serializer.Serialize(stream, books);
            }
        }


    }
}
