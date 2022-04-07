using System.Linq.Expressions;
using CloudEmployees.Entities.Abstract;

namespace CloudEmployees.DataAccess.Services.Abstract;

public interface IEntityService<T> where T : class, IEntity, new() {
  public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, string? includeProperties);
  public T GetById(Guid id);
  public T Create(T entity);
  public T Remove (T entity);
  public T Update(T entity);
   
}