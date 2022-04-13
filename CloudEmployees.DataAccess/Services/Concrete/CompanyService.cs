using CloudEmployees.DataAccess.DataContext;
using CloudEmployees.DataAccess.Services.Abstract;
using CloudEmployees.Entities.Concrete;

namespace CloudEmployees.DataAccess.Services.Concrete;
public class CompanyService: BaseEntityService<Company>, ICompanyService {
  readonly CloudEmployeesContext _context;
  public CompanyService(CloudEmployeesContext context) : base(context) {
    _context = context;
   }

}