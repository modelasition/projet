using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation_CRUD
{
    internal class Book
    {       
        public string ISBN { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Author> Authors { get; set; }

        public Book(string iSBN, string titre, string description, Category category)
        {
            ISBN = iSBN;
            Titre = titre;
            Description = description;
            Category = category;
        }

        public Book()
        {
        }

        public override string? ToString()
        {
            return Titre + " " + Category + " " + Authors;
        }
    }
}
