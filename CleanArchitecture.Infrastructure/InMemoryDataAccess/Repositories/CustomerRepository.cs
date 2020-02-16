using CleanArchitecture.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Infrastructure.InMemoryDataAccess.Repositories
{
    public class CustomerRepository :
        Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository()
        {
            Collection = new List<Customer>()
            {
                new Customer(Guid.NewGuid(), "João", "123456"),
                new Customer(Guid.NewGuid(), "Maria", "123456"),
                new Customer(Guid.NewGuid(), "Paulo", "123456"),
                new Customer(Guid.NewGuid(), "Sara", "123456"),
                new Customer(Guid.NewGuid(), "Bruno", "123456"),
                new Customer(Guid.NewGuid(), "Pedro", "123456"),
                new Customer(Guid.NewGuid(), "Gabriela", "123456"),
                new Customer(Guid.NewGuid(), "Larissa", "123456"),
                new Customer(Guid.NewGuid(), "Fernanda", "123456"),
                new Customer(Guid.NewGuid(), "Camila", "123456"),
                new Customer(Guid.NewGuid(), "Jefferson", "123456"),
            }
            .AsQueryable();
        }
    }
}
