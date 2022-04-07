using CloudEmployees.Entities.Abstract;

namespace CloudEmployees.Entities.Concrete;

public class Department : IEntity{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public List<Employee>? Employees { get; set; }
  public Company Company { get; set; }
}
