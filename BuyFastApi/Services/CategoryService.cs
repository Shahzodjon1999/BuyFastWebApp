using BuyFastApi.InterfaceServices;
using BuyFastDTO;

namespace BuyFastApi.Services;

public class CategoryService:IGenericService<CategoryDto, CategoryDto, CategoryDto>
{
    public string Create(CategoryDto item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CategoryDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public CategoryDto GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public string Update(CategoryDto item)
    {
        throw new NotImplementedException();
    }

    public string Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}