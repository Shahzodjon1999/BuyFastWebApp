using BuyFastApi.Infrastructure;
using BuyFastApi.InterfaceRepositoryes;
using BuyFastApi.Models;

namespace BuyFastApi.Repositories;

public class CartItemRepository: BaseRepository<CartItem>, ICartItemRepository
{
    private readonly AppDbContext _context;
    public CartItemRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}