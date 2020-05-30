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
    public class GoodsController : ControllerBase
    {
        private readonly OrderContext orderDB;

        public GoodsController(OrderContext context)
        {
            orderDB = context;
        }


        // GET: api/Goods/5
        [HttpGet("{id}")]
        public ActionResult<List<Goods>> GetAllGoods()
        {
            IQueryable<Goods> query = orderDB.Goods;

            return query.ToList();
        }

        // GET: api/Items/5
        //依据id查询商品
        [HttpGet("{id}")]
        public ActionResult<Goods> GetGoodsByID(string id)
        {
            Goods goods;
            IQueryable<Goods> query = orderDB.Goods;
            query = query.Where(t => t.ID == id);
            goods = query.FirstOrDefault();
            return goods;
        }

        //依据价格查询商品,小于等于均可
        [HttpGet("{id}")]
        public ActionResult<List<Goods>> GetItemByOrderID(int  price)
        {
            IQueryable<Goods> query = orderDB.Goods;
            query = query.Where(t => t.Price<=price);

            return query.ToList();
        }

        // POST: api/Orders
        //添加新商品
        [HttpPost]
        public ActionResult<Goods> PostItem(Goods goods)
        {

            try
            {
                orderDB.Goods.Add(goods);
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                //返回错误信息
                return BadRequest(e.InnerException);
            }

            return goods;
        }

        // PUT: api/Orders/5
        //修改商品信息
        [HttpPut("{id}")]
        public ActionResult<Item> PutItem(string id, Goods goods,double? price,string? name)
        {
            if (id != goods.ID)
            {
                return BadRequest();
            }
            try
            {
                orderDB.Entry(goods).State = EntityState.Modified;
                goods.Name = name;
                goods.Price = (double)price;
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                //返回错误信息
                return BadRequest(e.InnerException);
            }

            return NoContent();
        }

        //删除订单
        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(string id)
        {
            try
            {
                var goods = orderDB.Goods.FirstOrDefault(t => t.ID == id);
                if (goods != null)
                {
                    orderDB.Remove(goods);
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

        private bool GoodsExists(string id)
        {
            return orderDB.Goods.Any(e => e.ID == id);
        }
    }
}
