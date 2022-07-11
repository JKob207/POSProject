using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSProject
{
    public class Customer_pizza
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int PizzaID { get; set; }
        public Pizza Pizza { get; set; }
        public int customerOrderID { get; set; }
        public Customer_order Customer_order { get; set; }

        public List<Customer_extra> customer_Extras { get; set;}
    }
}
