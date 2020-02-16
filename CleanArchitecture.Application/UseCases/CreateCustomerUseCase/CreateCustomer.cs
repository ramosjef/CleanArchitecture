using CleanArchitecture.Domain.Customers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.CreateCustomerUseCase
{
    public class CreateCustomer : IRequestHandler<CreateCustomerCommand, Guid>
    {
        public ICustomerRepository _customerRepository { get; }

        public CreateCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Guid> Handle(
            CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name, request.DocumentNumber);

            var response = _customerRepository.Add(customer);

            return Task.FromResult(response);
        }
    }
}
