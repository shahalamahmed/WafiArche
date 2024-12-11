using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WafiArche.Domain.Shippers
{
    public class Shipper
    {  
        public int ShipperID { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
    }
}
