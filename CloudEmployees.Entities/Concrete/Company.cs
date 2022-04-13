using CloudEmployees.Entities.Abstract;

namespace CloudEmployees.Entities.Concrete;

public class Company : IEntity {
  public Guid Id { get; set; }
  public string Name { get; set; }
  public Address Address { get; set; }
  public List<Department>? Departments { get; set; }
  public List<Employee>? Employees { get; set; }
}