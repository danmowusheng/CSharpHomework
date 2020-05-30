using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManager2._0
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }
        public Customer(string name)
        {            
            TimeSpan ts = DateTime.UtcNow - new DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.CustomerName = name;
            this.CustomerID = Convert.ToInt32(ts.TotalSeconds);
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer!=null &&
                   CustomerID == customer.CustomerID &&
                   CustomerName == customer.CustomerName;
        }

        public override int GetHashCode()
        {
            var hashCode = 644752014;
            hashCode = hashCode * -1521134295 + CustomerID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
            return hashCode;
        }
    }
}
