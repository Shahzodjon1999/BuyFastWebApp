using AutoMapper;
using BuyFastApi.InterfaceRepositoryes;
using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.ResponseModel;

namespace BuyFastApi.Services;

public class CartItemService: IGenericService<CartDto,CardItemResponse,CartItem>
{
    private readonly ICartItemRepository _repository;
    private readonly IMapper _mapper;
    public CartItemService(ICartItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public string Create(CartDto item)
    {
        var map = _mapper.Map<CartItem>(item);
        _repository.Create(map);

        return $"Created new item with this ID: {map.Id}";
    }

    public IEnumerable<CartItem> GetAll()
    {
        try
        {
            var getDoctors = _repository.GetAll();
            if (getDoctors != null)
                return _mapper.Map<IEnumerable<CartItem>>(getDoctors);
            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public CartItem GetById(Guid id)
    {
        try
        {
            var mapDoctorResponse = _repository.GetById(id);
            if (mapDoctorResponse is null)
            {
                return null;
            }
            return _mapper.Map<CartItem>(mapDoctorResponse);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public string Update(CardItemResponse item)
    {
        var _item = _repository.GetById(item.Id);
        if (_item is null)
        {
            return "Item is not found";
        }
        var map = _mapper.Map<CartItem>(item);
        map.Id = _item.Id;
        _repository.Update(map);
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