using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WafiArche.Application.Categories.Dtos
{
    public class CategoryDto
    {
        public int CategoryID { get; set; }  // Add this property
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

}
