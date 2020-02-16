using System.Collections.Generic;
using CleanArchitecture.Application.UseCases.GetCustomerUseCase;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CleanArchitecture.Application.UseCases.CreateCustomerUseCase;
using System.Threading.Tasks;
using System;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Listar os clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [HttpGet(Name = "GetCustomer")]
        public Task<IEnumerable<CustomerReponse>> GetCustomers()
        {
            var response = _mediator.Send(new GetCustomersQuery());
            return response;
        }

        /// <summary>
        /// Criar um novo cliente
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Name = "PostCustomer")]
        public Task<Guid> Post(CreateCustomerCommand command)
        {
            var response = _mediator.Send(command);
            return response;
        }
    }
}