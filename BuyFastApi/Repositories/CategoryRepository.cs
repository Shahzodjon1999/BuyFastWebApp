using BuyFastApi.Infrastructure;
using BuyFastApi.InterfaceRepositoryes;
using BuyFastApi.Models;

namespace BuyFastApi.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}