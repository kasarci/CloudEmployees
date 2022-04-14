namespace CloudEmployees.Entities.Concrete;
public class EmployeeManager {
  public Guid EmployeeManagerId { get; set; }
  public virtual Employee Manager { get; set; }

  public virtual ICollection<Employee> Employee { get; set; }
}
