using BuyFastApi.Infrastructure;
using BuyFastApi.InterfaceRepositoryes;
using BuyFastApi.Models;

namespace BuyFastApi.Repositories;

public class ProductRepository:BaseRepository<Product>,IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}