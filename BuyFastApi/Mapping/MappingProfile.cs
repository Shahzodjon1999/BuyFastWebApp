using AutoMapper;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.RequestModels;

namespace BuyFastApi.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<UserProfile, UserProfileDto>().ReverseMap();
        CreateMap<Product,CreateProductDto>().ReverseMap();
        CreateMap<CreateProductDto, Product>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<Review, ReviewDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<Cart, CartDto>().ReverseMap();
        CreateMap<CartItem, CartItemDto>().ReverseMap();
        CreateMap<Wishlist, WishlistDto>().ReverseMap();
        CreateMap<WishlistItem, WishlistItemDto>().ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<Rating, RatingDto>().ReverseMap();
    }
}