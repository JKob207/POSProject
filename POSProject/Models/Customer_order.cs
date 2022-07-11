using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSProject
{
    public class Customer_order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Total_price { get; set; }

        public List<Customer_pizza> customer_Pizzas { get; set; }
        public List<Customer_drink> customer_Drinks { get; set; }
    }
}
