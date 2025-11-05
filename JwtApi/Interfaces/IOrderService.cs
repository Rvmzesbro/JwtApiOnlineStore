using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Interfaces
{
    public interface IOrderService
    {
        Task<ActionResult> GetAllOrders();
        Task<ActionResult> EditStatusOrder(int Id, int StatusId);
    }
}
