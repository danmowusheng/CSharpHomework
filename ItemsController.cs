using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderWeb.Model;

namespace OrderWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly OrderContext orderDB;

        public ItemsController(OrderContext context)
        {
            orderDB = context;
        }

        // GET: api/Items
        //获取所有订单项
        [HttpGet]
        public ActionResult<List<Item>> GetAllOrderItems()
        {
            IQueryable<Item> query = orderDB.Items;

            return query.ToList();
        }

        // GET: api/Items/5
        //依据id查询订单项
        [HttpGet("{id}")]
        public ActionResult<Item> GetItemByID(string id)
        {
            Item item;
            IQueryable<Item> query = orderDB.Items;
            query = query.Where(t => t.Id == id);
            item = query.FirstOrDefault();
            return item;
        }

        //依据订单号id查询订单项
        [HttpGet("{id}")]
        public ActionResult<List<Item>> GetItemByOrderID(string orderID)
        {            
            IQueryable<Item> query = orderDB.Items;
            query = query.Where(t => t.OrderId == orderID);

            return query.ToList();
        }

        // POST: api/Orders
        //添加订单明细项
        [HttpPost]
        public ActionResult<Item> PostItem(Item item)
        {

            try
            {
                orderDB.Items.Add(item);
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                //返回错误信息
                return BadRequest(e.InnerException);
            }

            return item;
        }

        // PUT: api/Orders/5
        //修改订单明细项
        [HttpPut("{id}")]
        public ActionResult<Item> PutItem(string id, Item item,string goodsID,double? price, string? name)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            try
            {
                orderDB.Entry(item).State = EntityState.Modified;
                Goods goods;
                goods = item.GoodsItem;
                GoodsController goodsController = new GoodsController(orderDB);
                goodsController.PutItem(goodsID, goods,price,name);
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                //返回错误信息
                return BadRequest(e.InnerException);
            }

            return NoContent();
        }

        //删除订单明细
        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                var item = orderDB.Items.FirstOrDefault(t => t.Id == id);
                if (item != null)
                {
                    orderDB.Remove(item);
                    orderDB.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //返回错误信息
                return BadRequest(e.InnerException);
            }

            return NoContent();
        }

        private bool ItemExists(string id)
        {
            return orderDB.Items.Any(e => e.Id == id);
        }
    }
}
