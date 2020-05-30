using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderWeb.Model
{
    public class Item
    {
        [Key]
        public string Id { get; set; }

        public int Index { get; set; } //序号

        public string GoodsItemId { get; set; }

        [ForeignKey("GoodsItemId")]
        public Goods GoodsItem { get; set; }
        public string OrderId { get; set; }

        public int Quantity { get; set; }
    }
}
