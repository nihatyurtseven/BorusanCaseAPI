using BorusanCaseAPI.Results;
using Entities;
using Entities.Dtos;
using Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BorusanCaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "Orders")]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await _context.Orders.Include(s=>s.Product).ToListAsync();
            return Ok(orders);
        }

        [HttpPost("addOrder")]
        public async Task<ActionResult<List<OrderResult>>> AddOrder(List<NewOrderDto> orders)
        {
            var orderResult = new List<OrderResult>();
            foreach (NewOrderDto order in orders) {
                var OrderResultItem = new OrderResult();
                OrderResultItem.CustomerOrderId = order.CustomerOrderId;
                try
                {
                    var dbOrder = _context.Orders.FirstOrDefault(x => x.CustomerOrderId == order.CustomerOrderId);
                    if (dbOrder != null)
                        throw new Exception("Customer order number already exists.");
                    //return BadRequest("Customer order number already exists.");


                    var dbProduct = _context.Products.FirstOrDefault(x => x.Code == order.ProductCode);
                    if (dbProduct == null)
                    {
                        dbProduct = new Product();
                        dbProduct.Id = Guid.NewGuid();
                        dbProduct.Code = order.ProductCode;
                        dbProduct.Name = order.ProductName;
                        dbProduct.CreatedDate = DateTime.Now;
                        _context.Products.Add(dbProduct);
                        await _context.SaveChangesAsync();
                    }

                    dbOrder = new Order();
                    dbOrder.Id = Guid.NewGuid();
                    dbOrder.StatusId = (int)OrderStatuses.SiparisAlindi;
                    dbOrder.CustomerOrderId = order.CustomerOrderId;
                    dbOrder.OutputAddress = order.OutputAddress;
                    dbOrder.ArrivalAddress = order.ArrivalAddress;
                    dbOrder.Quantity = order.Quantity;
                    dbOrder.QuantityType = order.QuantityType;
                    dbOrder.Weight = order.Weight;
                    dbOrder.WeightType = order.WeightType;
                    dbOrder.ProductId = dbProduct.Id;
                    dbOrder.Note = order.Note;
                    dbOrder.CreatedDate = DateTime.Now;

                    _context.Orders.Add(dbOrder);
                    await _context.SaveChangesAsync();

                    OrderResultItem.OrderId = dbOrder.Id;
                    OrderResultItem.Statu = 0; //başarılı
                    OrderResultItem.Message = "Kaydetme işlemi başarı ile gerçekleşti";
                }
                catch (Exception ex)
                {
                    OrderResultItem.Statu = 1; //hatalı
                    OrderResultItem.Message = "Kaydetme işlemi sırasında hata: " + ex.Message;
                }
                orderResult.Add(OrderResultItem);

            }
            

            return Ok(orderResult);
        }

        [HttpPost("updateOrderStatu")]
        public async Task<ActionResult<OrderResult>> UpdateOrderStatu(OrderStatuDto orderStatuDto)
        {
            var orderResult = new OrderResult();
            orderResult.CustomerOrderId = orderStatuDto.CustomerOrderId;

            try {
                var dbOrder = await _context.Orders.FirstOrDefaultAsync(x => x.CustomerOrderId == orderStatuDto.CustomerOrderId);
                if (dbOrder == null)
                    throw new Exception("Customer order not found.");

                dbOrder.StatusId = orderStatuDto.StatusId;
                dbOrder.UpdatedDate = orderStatuDto.ChangeDate;

                //_context.Orders.Update(dbOrder);
                await _context.SaveChangesAsync();
                
                orderResult.OrderId = dbOrder.Id;
                orderResult.Statu = 0; //başarılı
                orderResult.Message = "Statü değiştirme işlemi başarı ile gerçekleşti.";
            }
            catch (Exception ex) {
                orderResult.Statu = 1; //hatalı
                orderResult.Message = "Statü değişikliği sırasında hata: " + ex.Message;
            }
            
            return Ok(orderResult);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Order>> Get(Guid id)
        //{
        //    var order = await _context.Orders.FindAsync(id);
        //    if (order == null)
        //        return BadRequest("Order not found.");
        //    return Ok(order);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<Order>>> Delete(Guid id)
        //{
        //    var dbOrder = await _context.Orders.FindAsync(id);
        //    if (dbOrder == null)
        //        return BadRequest("Order not found.");

        //    _context.Orders.Remove(dbOrder);
        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.Orders.ToListAsync());
        //}
    }
}
