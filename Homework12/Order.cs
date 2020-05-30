using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderWeb.Model
{
    public class Order
    {
        [Key]
        public string Id { get; set; }

        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]

        public DateTime CreateTime { get; set; }

        public List<Item> Items { get; set; }
    }
}
