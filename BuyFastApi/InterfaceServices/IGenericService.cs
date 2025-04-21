namespace BuyFastApi.InterfaceServices;

public interface IGenericService<TRequest,TUpdate,TResponse> where TRequest : class  where TResponse : class where TUpdate : class
{
    string Create(TRequest item); 

    IEnumerable<TResponse> GetAll();

    TResponse GetById(Guid id);

    string Update(TUpdate item);

    string Delete(Guid id);
}