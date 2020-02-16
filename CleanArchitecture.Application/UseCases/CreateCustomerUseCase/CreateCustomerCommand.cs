using MediatR;
using System;

namespace CleanArchitecture.Application.UseCases.CreateCustomerUseCase
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
    }
}
