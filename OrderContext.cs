using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;

namespace OrderWeb.Model
{
    public class OrderContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options):base(options)
        {
            this.Database.EnsureCreated();
        }
        
        public Microsoft.EntityFrameworkCore.DbSet<Order> Orders { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Item> Items { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Goods> Goods { get; set; }
    }
}
