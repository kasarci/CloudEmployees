using CloudEmployees.DataAccess.DataContext;
using CloudEmployees.DataAccess.Services.Abstract;
using CloudEmployees.Entities.Concrete;

namespace CloudEmployees.DataAccess.Services.Concrete;
public class AddressService: BaseEntityService<Address>, IAddressService {
  readonly CloudEmployeesContext _context;
  public AddressService(CloudEmployeesContext context) : base(context) {
    _context = context;
   }

}