namespace BuyFastApi.InterfaceServices;

public interface IGenericService<TRequest,TUpdateRequest,TResponse> where TRequest : class where TUpdateRequest:class where TResponse : class
{
    string Create(TRequest item); 

    IEnumerable<TResponse> GetAll();

    TResponse GetById(Guid id);

    string Update(TUpdateRequest item);

    string Delete(Guid id);
}