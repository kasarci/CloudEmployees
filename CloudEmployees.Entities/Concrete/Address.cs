using CloudEmployees.Entities.Abstract;

namespace CloudEmployees.Entities.Concrete;

public class Address : IEntity {
  public Guid Id { get; set; }
  public string Street { get; set; }
  public string City { get; set; }
  public string Zipcode { get; set; }
  public string Country { get; set; }
  public Guid? CompanyId { get; set; }
  public Company? Company { get; set; }
  public Guid? EmployeeId { get; set; }
  public Employee? Employee { get; set; }
}
