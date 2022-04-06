namespace CloudEmployees.Entities.Concrete;

public class Address {
  public Guid Id { get; set; }
  public string Street { get; set; }
  public string City { get; set; }
  public string Zipcode { get; set; }
  public Company? Company { get; set; }
  public Employee? Employee { get; set; }
}
