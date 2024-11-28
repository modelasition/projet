using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation_CRUD
{
    public class Author
    {
        public Author()
        {
        }

        public Author(int id_Author, string lastName, string firstName)
        {
            Id_Author = id_Author;
            LastName = lastName;
            FirstName = firstName;
        }

        public int Id_Author {  get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
