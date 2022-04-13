using CloudEmployees.DataAccess.DataContext;
using CloudEmployees.DataAccess.Services.Abstract;
using CloudEmployees.Entities.Concrete;

namespace CloudEmployees.DataAccess.Services.Concrete;
public class EmployeeService : BaseEntityService<Employee>, IEmployeeService {
  readonly CloudEmployeesContext _context;
  public EmployeeService(CloudEmployeesContext context) : base(context) { 
    _context = context;
  }

}