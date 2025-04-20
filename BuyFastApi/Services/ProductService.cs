using AutoMapper;
using BuyFastApi.InterfaceRepositoryes;
using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;
using BuyFastDTO.RequestModels;

namespace BuyFastApi.Services;

public class ProductService : IGenericService<CreateProductDto, Product>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public string Create(CreateProductDto item)
    {
        if (string.IsNullOrEmpty(item.Name))
        {
            return "The name cannot be empty";
        }
        var mapDoctor = _mapper.Map<Product>(item);
        _productRepository.Create(mapDoctor);

        return $"Created new item with this ID: {mapDoctor.Id}";
    }

    public IEnumerable<Product> GetAll()
    {
        try
        {
            var getItems = _productRepository.GetAll();
            if (getItems != null)
                return _mapper.Map<IEnumerable<Product>>(getItems);
            return null;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public Product GetById(Guid id)
    {
        try
        {
            var mapDoctorResponse = _productRepository.GetById(id);
            if (mapDoctorResponse is null)
            {
                return null;
            }
            return _mapper.Map<Product>(mapDoctorResponse);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public string Update(CreateProductDto item)
    {
        var _item = _productRepository.GetById(item.Id);
        if (_item is null)
        {
            return "Item is not found";
        }
        var mapItem = _mapper.Map<Product>(item);
        mapItem.Id = _item.Id;
        _productRepository.Update(mapItem);
        return "Item is updated";
    }

    public string Delete(Guid id)
    {
        var _item = _productRepository.GetById(id);
        if (_item is null)
        {
            return "Item is not found";
        }
        _productRepository.Delete(id);

        return "Item is deleted";
    }

}