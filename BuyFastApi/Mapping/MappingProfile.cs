using AutoMapper;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.RequestModels;
using BuyFastDTO.ResponseModel;

namespace BuyFastApi.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<ProductResponse, Product>().ReverseMap();
        CreateMap<ProductRequest, Product>().ReverseMap();

        CreateMap<CategoryResponse, Category>().ReverseMap();
        CreateMap<CategoryRequest, Category>().ReverseMap();

        //CreateMap<User, UserDto>().ReverseMap();
        //CreateMap<UserProfile, UserProfileDto>().ReverseMap();
        //CreateMap<Review, ReviewDto>().ReverseMap();
        //CreateMap<Order, OrderDto>().ReverseMap();
        //CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        //CreateMap<Cart, CartDto>().ReverseMap();
        //CreateMap<CartItem, CartItemDto>().ReverseMap();
        //CreateMap<Wishlist, WishlistDto>().ReverseMap();
        //CreateMap<WishlistItem, WishlistItemDto>().ReverseMap();
        //CreateMap<Payment, PaymentDto>().ReverseMap();
        //CreateMap<Rating, RatingDto>().ReverseMap();
    }
}