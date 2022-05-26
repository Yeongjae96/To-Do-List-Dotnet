using TodoList.Interfaces;
using Microsoft.EntityFrameworkCore;
using TodoList.Context;
using TodoList.Entities;

namespace TodoList.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
  protected ApplicationDbContext Db { get; }
  protected DbSet<TEntity> DbSet { get; }

  public Repository(ApplicationDbContext dbContext)
  {
    Db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    DbSet = Db.Set<TEntity>();
  }


  public virtual TEntity Create(TEntity entity)
  {
    DbSet.Add(entity);
    return entity;
  }

  public virtual async Task Delete<TKey>(TKey id)
  {
    var entity = await DbSet.FindAsync(id);
    if (entity != null) DbSet.Remove(entity);
  }

  public virtual IQueryable<TEntity> GetAll()
  {
    return DbSet.AsNoTracking();
  }

  public virtual async Task<TEntity> GetById<TKey>(TKey id)
  {
    foreach (var property in typeof(TEntity).GetProperties())
    {
      var keyAttribute = property.CustomAttributes.FirstOrDefault(attribute => attribute.AttributeType);
      return await DbSet
                  .AsNoTracking()
                  .FirstOrDefaultAsync(e => e.Id == id);
    }

  }

  public virtual async Task<int> SaveChangesAsync()
  {
    return await Db.SaveChangesAsync();
  }

  public virtual TEntity Update(TEntity entity)
  {
    DbSet.Update(entity);
    return entity;
  }

  
  public void Dispose()
  {
    throw new NotImplementedException();
  }
}