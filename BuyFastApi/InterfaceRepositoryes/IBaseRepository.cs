using BuyFastApi.Abstracts;

namespace BuyFastApi.InterfaceRepositoryes;

public interface IBaseRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();

    T GetById(Guid id);

    T Create(T item);

    bool Update(T item);

    bool Delete(Guid id);
}