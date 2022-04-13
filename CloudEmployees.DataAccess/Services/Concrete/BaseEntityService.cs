using System.Linq.Expressions;
using CloudEmployees.DataAccess.DataContext;
using CloudEmployees.DataAccess.Services.Abstract;
using CloudEmployees.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CloudEmployees.DataAccess.Services;

public class BaseEntityService<T> : IEntityService<T> where T : class, IEntity, new() {

  private readonly CloudEmployeesContext _context;
  internal DbSet<T> dbSet;

  public BaseEntityService(CloudEmployeesContext context) {
    _context = context;
    this.dbSet = _context.Set<T>();
  }

  public T Create(T entity) {
    var result = dbSet.Add(entity);
    return result.Entity;
  }

  public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, string? includeProperties) {
    IQueryable<T> query = dbSet;

    if (filter is not null) {
      query = query.Where(filter);
    }

    if (includeProperties is not null) {
      foreach (var item in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
      {
        query = query.Include(item);
      }
    }

    if (orderBy is not null) {
      return orderBy(query);
    }
    return query;
  }

  public T GetById(Guid id) {
    return dbSet.First<T>(e => e.Id == id );
  }

  public T Remove(T entity) {
    var result = dbSet.Remove(entity);
    return result.Entity;
  }

  public T Update(T entity) {
    var result = dbSet.Update(entity);
    return result.Entity;
  }
}