using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WafiArche.Domain.Categories
{
    public class Category
    {
        public int CategoryID { get; set; } // Matches the database column name
        public string CategoryName { get; set; } // Matches the database column name
        public string Description { get; set; } // Matches the database column name

    }
}
