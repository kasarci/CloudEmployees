using CloudEmployees.Entities.Abstract;

namespace CloudEmployees.Entities.Concrete;

public class Company : IEntity {
  public Guid Id { get; set; }
  public string Name { get; set; }
  public Guid AddressId { get; set; }
  public Address Address { get; set; }
  public ICollection<Department>? Departments { get; set; }
  public ICollection<Employee>? Employees { get; set; }
}