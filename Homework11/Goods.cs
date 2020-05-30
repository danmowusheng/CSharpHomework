using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager2._0
{
    public class Goods
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Goods()
        {
        }

        public Goods(string name, double price)
        {
            //生成唯一标识符
            ID = Guid.NewGuid().ToString();
            Name = name;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null &&
                   ID == goods.ID &&
                   Name == goods.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 560300832;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
}
