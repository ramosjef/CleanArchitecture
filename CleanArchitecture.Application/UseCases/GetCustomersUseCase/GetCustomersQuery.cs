using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Application.UseCases.GetCustomerUseCase
{
    public class GetCustomersQuery : IRequest<IEnumerable<CustomerReponse>>
    {
    }
}
