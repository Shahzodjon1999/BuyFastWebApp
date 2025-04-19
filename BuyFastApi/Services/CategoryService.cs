using AutoMapper;
using BuyFastApi.InterfaceRepositoryes;
using BuyFastApi.InterfaceServices;
using BuyFastApi.Models;
using BuyFastDTO;

namespace BuyFastApi.Services;

public class CategoryService: IGenericService<CategoryDto, Category>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public string Create(CategoryDto item)
    {
        if (string.IsNullOrEmpty(item.Name))
        {
            return "The name cannot be empty";
        }
        var mapDoctor = _mapper.Map<Category>(item);
        _categoryRepository.Create(mapDoctor);

        return $"Created new item with this ID: {mapDoctor.Id}";
    }

    public IEnumerable<Category> GetAll()
    {
        try
        {
            var getDoctors = _categoryRepository.GetAll();
            if (getDoctors != null)
                return _mapper.Map<IEnumerable<Category>>(getDoctors);
            return null;
        }
        catch (Exception)
        {
           return null;
        }
    }

    public Category GetById(Guid id)
    {
        try
        {
            var mapDoctorResponse = _categoryRepository.GetById(id);
            if (mapDoctorResponse is null)
            {
                return null;
            }
            return _mapper.Map<Category>(mapDoctorResponse);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public string Update(CategoryDto item)
    {
        var _item = _categoryRepository.GetById(item.Id);
        if (_item is null)
        {
            return "Item is not found";
        }
        var mapDoctor = _mapper.Map<Category>(item);
        mapDoctor.Id = _item.Id;
        _categoryRepository.Update(mapDoctor);
        return "Item is updated";
    }

    public string Delete(Guid id)
    {
        var _item = _categoryRepository.GetById(id);
        if (_item is null)
        {
            return "Item is not found";
        }
        _categoryRepository.Delete(id);

        return "Item is deleted";
    }

}