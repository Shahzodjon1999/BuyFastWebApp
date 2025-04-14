using BuyFastApi.Abstracts;
using BuyFastApi.Infrastructure;
using BuyFastApi.InterfaceRepositoryes;
using Microsoft.EntityFrameworkCore;

namespace BuyFastApi.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    protected readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public T Create(T item)
    {
        try
        {
            _dbSet.Add(item);
            _context.SaveChanges();
            return item;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool Delete(Guid id)
    {
        try
        {
            var item = GetById(id);
            _dbSet.Remove(item);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public virtual IQueryable<T> GetAll()
    {
        try
        {
            return _dbSet.AsQueryable();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public T GetById(Guid id)
    {
        try
        {
            return _dbSet.FirstOrDefault(p => p.Id == id);
        }
        catch (Exception)
        {
          return null;
        }
    }

    public virtual bool Update(T item)
    {
        try
        {
            var itemResult = GetById(item.Id);

            _context.Entry(itemResult).State = EntityState.Detached;
            item.Id = item.Id;
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
          return false;           
        }
    }
}

