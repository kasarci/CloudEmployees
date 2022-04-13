using System.Linq.Expressions;
using CloudEmployees.DataAccess.Services.Abstract;
using CloudEmployees.Entities.Abstract;

namespace CloudEmployees.DataAccess.Services;

public class BaseEntityService<T> : IEntityService<T> where T : class, IEntity, new() {
  public T Create(T entity) {
    throw new NotImplementedException();
  }

  public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, string? includeProperties) {
    throw new NotImplementedException();
  }

  public T GetById(Guid id) {
    throw new NotImplementedException();
  }

  public T Remove(T entity) {
    throw new NotImplementedException();
  }

  public T Update(T entity) {
    throw new NotImplementedException();
  }
}