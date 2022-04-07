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
  public DateOnly StartDate { get; set; }
  public Address Address { get; set; }
  public Department Department { get; set; }
  public Company Company { get; set; }
  public List<Employee>? Subordinates { get; set; }
  public Employee? Manager { get; set; }
  
}

