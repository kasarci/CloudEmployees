using System.Linq.Expressions;
using CloudEmployees.Entities.Abstract;

namespace CloudEmployees.DataAccess.Services.Abstract;

public interface IEntityService<T> where T : class, IEntity, new() {
  public Task<List<T>> GetAll(Expression<Func<T, bool>>? filter, Func<List<T>, List<T>>? orderBy, string? includeProperties);
  public Task<T> GetById(Guid id);
  public Task<bool> Create(T entity);
  public Task<bool> Remove (Guid Id);
  public Task<bool> Update(T entity);
   
}