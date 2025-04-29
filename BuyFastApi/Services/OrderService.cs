using AutoMapper;
using BuyFastApi.InterfaceRepositoryes;
using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.RequestModels;
using BuyFastDTO.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace BuyFastApi.Services;

public class OrderService:IGenericService<OrderRequest, OrderResponse, Order>
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    public OrderService(IOrderRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    
    public string Create(OrderRequest item)
    {
        var order = new Order
        {
            UserId = item.UserId,
            OrderDate = DateTime.UtcNow,
            ShippingAddress = item.ShippingAddress,
            Status = "Pending",
            TotalAmount = item.Items.Sum(x => x.UnitPrice * x.Quantity),
            OrderItems = item.Items.Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice
            }).ToList()
        };

        _repository.Create(order);

        return $"Created new item with this ID: {order.Id}";
    }

    public IEnumerable<Order> GetAll()
    {
        try
        {
            var getItems = _repository.GetAll();
            if (getItems != null)
                return _mapper.Map<IEnumerable<Order>>(getItems);
            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public Order GetById(Guid id)
    {
        try
        {
            var mapDoctorResponse = _repository.GetById(id);
            if (mapDoctorResponse is null)
            {
                return null;
            }
            return _mapper.Map<Order>(mapDoctorResponse);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public string Update(OrderResponse item)
    {
        var _item = _repository.GetById(item.Id);
        if (_item is null)
        {
            return "Item is not found";
        }
        var mapItem = _mapper.Map<Order>(item);
        mapItem.Id = _item.Id;
        _repository.Update(mapItem);
        return "Item is updated";
    }

    public string Delete(Guid id)
    {
        var _item = _repository.GetById(id);
        if (_item is null)
        {
            return "Item is not found";
        }
        _repository.Delete(id);

        return "Item is deleted";
    }
}