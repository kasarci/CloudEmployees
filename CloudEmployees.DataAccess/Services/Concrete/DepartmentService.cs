using CloudEmployees.DataAccess.DataContext;
using CloudEmployees.DataAccess.Services.Abstract;
using CloudEmployees.Entities.Concrete;

namespace CloudEmployees.DataAccess.Services.Concrete;
public class DepartmentService: BaseEntityService<Department>, IDepartmentService {
  readonly CloudEmployeesContext _context;
  public DepartmentService(CloudEmployeesContext context) : base(context) {
    _context = context;
   }

}