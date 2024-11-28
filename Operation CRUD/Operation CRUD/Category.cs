using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation_CRUD
{
    public class Category
    {
        public Category()
        {
        }

        public Category(int id_Category, string categoryName)
        {
            Id_Category = id_Category;
            CategoryName = categoryName;
        }

        public int Id_Category {  get; set; }
        public string CategoryName {  get; set; }
    }
}
