using CloudEmployees.Entities.Abstract;

namespace CloudEmployees.Entities.Concrete;

public class Department : IEntity{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public Guid CompanyId { get; set; }
  public Company Company { get; set; }
  public ICollection<Employee>? Employees { get; set; }
}
