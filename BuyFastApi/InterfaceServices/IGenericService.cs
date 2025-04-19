namespace BuyFastApi.InterfaceServices;

public interface IGenericService<TEntityDto,TResponse> where TEntityDto : class  where TResponse : class
{
    string Create(TEntityDto item); 

    IEnumerable<TResponse> GetAll();

    TResponse GetById(Guid id);

    string Update(TEntityDto item);

    string Delete(Guid id);
}