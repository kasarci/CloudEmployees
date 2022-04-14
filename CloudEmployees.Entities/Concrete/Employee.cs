using CloudEmployees.Entities.Abstract;
using CloudEmployees.Entities.Enums;

namespace CloudEmployees.Entities.Concrete;

public class Employee : IEntity {
  public Guid Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Title { get; set; }
  public string Email { get; set; }
  public string PhoneNumber { get; set; }
  public Gender Gender { get; set; }
  public DateOnly BirthDate { get; set; }
  public DateOnly EmploymentDate { get; set; }
  public Guid AddressId { get; set; }
  public Address Address { get; set; }
  public Guid DepartmentId { get; set; }
  public Department Department { get; set; }
  public Guid CompanyId { get; set; }
  public Company Company { get; set; }
  public Guid ManagerId { get; set; }
  public EmployeeManager? Manager { get; set; }
  public ICollection<EmployeeSubordinate>? Subordinates { get; set; }
  
}

