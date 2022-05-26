using TodoList.Entities;

namespace TodoList.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
  IQueryable<TEntity> GetAll();

  Task<TEntity> GetById<TKey>(TKey id);

  TEntity Create(TEntity entity);

  TEntity Update(TEntity entity);

  Task Delete<TKey>(TKey id);

  Task<int> SaveChangesAsync();
}