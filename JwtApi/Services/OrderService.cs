using JwtApi.Interfaces;
using JwtApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly ContextDB db;
        public OrderService(ContextDB contextDB)
        {
            db = contextDB;
        }

        public async Task<ActionResult> GetAllOrders()
        {
            var ListOrders = await db.Orders.ToListAsync();

            if (ListOrders.Count == 0 || ListOrders == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            return new OkObjectResult(new
            {
                status = true,
                list = ListOrders
            });
        }

        public async Task<ActionResult> EditStatusOrder(int Id, int StatusId)
        {
            var ListOrders = await db.Orders.Where(p => p.Id == Id).ToListAsync();
            if(ListOrders.Count == 0 || ListOrders == null)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            foreach(var order in ListOrders)
            {
                order.StatusId = StatusId;
            }

            await db.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true,
                list = ListOrders
            });
        }

        public async Task<ActionResult> ReportSales(int Id)
        {
            var order = await db.Orders.Where(p => p.StatusId == 4 && p.Id == Id).ToListAsync();
            var content_order = await db.Baskets.Where(p => p.OrderId == Id).ToListAsync();

            if(order == null || content_order == null || order.Count == 0 || content_order.Count == 0)
            {
                return new OkObjectResult(new
                {
                    status = false
                });
            }

            return new OkObjectResult(new
            {
                status = true,
                order = order,
                content_order = content_order
            });
        }
    }
}
