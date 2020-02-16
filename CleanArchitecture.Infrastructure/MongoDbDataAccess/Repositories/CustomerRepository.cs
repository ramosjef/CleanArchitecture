using CleanArchitecture.Domain.Customers;
using MongoDB.Driver;

namespace CleanArchitecture.Infrastructure.MongoDbDataAccess.Repositories
{
    public class CustomerRepository :
        Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Context context)
            : base(context, "customers")
        {
        }
    }
}
