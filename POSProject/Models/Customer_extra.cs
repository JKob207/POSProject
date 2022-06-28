using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSProject
{
    public class Customer_extra
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Quantity { get; set; }
        public Customer_pizza customer_Pizza { get; set; }
        public Extra Extra { get; set; }
    }
}
