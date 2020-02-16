using CleanArchitecture.Domain.Customers;

namespace CleanArchitecture.Infrastructure.EntityFrameworkDataAccess.Repositories
{
    public class CustomerRepository :
        Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Context context)
            : base(context)
        {

        }
    }
}
