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
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext orderDB;

        public OrdersController(OrderContext context)
        {
            this.orderDB= context;
        }

        // GET: api/Orders  
        //查询参数为顾客号
        [HttpGet]
        public  ActionResult<List<Order>> GetOrdersBYCustomerID(string CustomerID)
        {
            IQueryable<Order> query = orderDB.Orders;
            query = query.Where(t => t.CustomerId == CustomerID);
            return query.ToList();
        }


        
        //查询参数为订单号
        [HttpGet]
        public Order GetOrdersBYID(string orderID)
        {
            Order order;
            IQueryable<Order> query = orderDB.Orders;
            query = query.Where(t => t.Id == orderID);
            order = query.FirstOrDefault();
            return order;
        }

        //返回所有order
        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders()
        {
            IQueryable<Order> query = orderDB.Orders;
            
            return query.ToList();
        }

        // POST: api/Orders
        //添加新订单
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {

            try
            {
                orderDB.Orders.Add(order);
                orderDB.SaveChanges();
            }
            catch (Exception e)
            {
                //返回错误信息
                return BadRequest(e.InnerException);
            }

            return order;
        }

        // PUT: api/Orders/5
        //修改订单
        [HttpPut("{id}")]
        public ActionResult<Order> PutOrder(string id, Order order,string itemID,string goodsID,double? price, string? name)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            try
            {
                orderDB.Entry(order).State = EntityState.Modified;
                Item it;
                it = order.Items.FirstOrDefault(o => o.Id == itemID);
                ItemsController itemsController = new ItemsController(orderDB);
                itemsController.PutItem(itemID, it,goodsID,price,name);
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
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                var order = orderDB.Orders.FirstOrDefault(t => t.Id == id);
                if (order != null)
                {
                    orderDB.Remove(order);
                    orderDB.SaveChanges();
                }
            }
            catch(Exception e)
            {
                //返回错误信息
                return BadRequest(e.InnerException);
            }

            return NoContent();
        }

        private bool OrderExists(string id)
        {
            return orderDB.Orders.Any(e => e.Id == id);
        }

        //订单的增删改查实现简单实现
    }
}
