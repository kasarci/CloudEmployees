namespace CloudEmployees.Entities.Concrete;
public class EmployeeSubordinate {
  public Guid EmployeeId { get; set; }
  public Employee Employee { get; set; }
  public Guid EmployeeSubordinateId { get; set; }
  public EmployeeSubordinate Subordinate{ get; set; }
}