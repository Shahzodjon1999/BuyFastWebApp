using BuyFastApi.Infrastructure;
using BuyFastApi.InterfaceRepositoryes;
using BuyFastApi.Models;

namespace BuyFastApi.Repositories;

public class OrderRepository:BaseRepository<Order>,IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}