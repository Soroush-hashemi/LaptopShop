using Common.Domain.Bases;
using Common.Domain.Repository;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Base;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly LaptopParhizgerContext _context;
    public BaseRepository(LaptopParhizgerContext context)
    {
        _context = context;
    }

    void IBaseRepository<TEntity>.Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRange(ICollection<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return _context.Set<TEntity>().Any(expression);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _context.Set<TEntity>().AnyAsync(expression);
    }

    public TEntity? Get(long id)
    {
        return _context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
    }

    public async Task<TEntity?> GetAsync(long id)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<TEntity?> GetTracking(long id)
    {
        return await _context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }

    public void Update(TEntity entity)
    {
        _context.Update(entity);
    }
}