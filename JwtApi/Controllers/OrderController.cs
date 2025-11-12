using JwtApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    public class OrderController
    {
        private readonly IOrderService service;
        public OrderController(IOrderService orderService)
        {
            service = orderService;
        }

        [HttpGet]
        [Route("/api/order/GetAllOrders")]
        public async Task<ActionResult> GetAllOrders()
        {
            return await service.GetAllOrders();
        }

        [HttpPut]
        [Route("/api/order/EditStatusOrder")]
        public async Task<ActionResult> EditStatusOrder(int Id, int StatusId)
        {
            return await service.EditStatusOrder(Id, StatusId);
        }

        [HttpGet]
        [Route("/api/order/ReportSales")]
        public async Task<ActionResult> ReportSales(int Id)
        {
            return await service.ReportSales(Id);
        }
    }
}
