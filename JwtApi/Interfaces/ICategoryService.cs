using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Interfaces
{
    public interface ICategoryService
    {
        Task<ActionResult> CreateCategory(string Name);
        Task<ActionResult> DeleteCategory(int Id);
        Task<ActionResult> GetCategories();
    }
}
