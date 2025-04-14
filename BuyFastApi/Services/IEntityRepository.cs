using BuyFastApi.Abstracts;

namespace BuyFastApi.Services;

public interface IEntityRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync(int? from = null, int? size = null);
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> CreateAsync(TEntity item);
    Task<TEntity> UpdateAsync(Guid id, TEntity item);
    Task<bool> DeleteAsync(Guid id);
}