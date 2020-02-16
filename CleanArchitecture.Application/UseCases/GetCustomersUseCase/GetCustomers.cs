using CleanArchitecture.Domain.Customers;
using System.Collections.Generic;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.GetCustomerUseCase
{
    public class GetCustomers : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerReponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomers(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<IEnumerable<CustomerReponse>> Handle(
            GetCustomersQuery request,
            CancellationToken cancellationToken)
        {
            var response = _customerRepository.GetAll();

            var viewModel = response.Select(c =>
                new CustomerReponse(c.Id, c.Name, c.DocumentNumber));

            return Task.FromResult(viewModel);
        }
    }
}
