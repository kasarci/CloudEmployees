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

  public async Task<bool> Create(T entity) {
    await dbSet.AddAsync(entity);
    var created = await _context.SaveChangesAsync();
    return created > 0;
  }

  public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter, Func<List<T>, List<T>>? orderBy, string? includeProperties) {
    IQueryable<T> query = dbSet;

    if (filter is not null) {
      query = (IQueryable<T>) query.Where(filter);
    }

    if (includeProperties is not null) {
      foreach (var item in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
      {
        query = query.Include(item);
      }
    }

    if (orderBy is not null) {
      return orderBy(await query.ToListAsync());
    }
    return await query.ToListAsync();
  }

  public async Task<T> GetById(Guid id) {
    return await dbSet.FirstOrDefaultAsync<T>(e => e.Id == id );
  }

  public async Task<bool> Remove(Guid Id) {
    var entity = await GetById(Id);
    if ( entity is null ) {
      return false;
    }
    dbSet.Remove(entity);
    var deleted = await _context.SaveChangesAsync();
    return deleted > 0;    
  }

  public async Task<bool> Update(T entity) {
    var result = dbSet.Update(entity);
    var updated = await _context.SaveChangesAsync();
    return updated > 0;
  }
}