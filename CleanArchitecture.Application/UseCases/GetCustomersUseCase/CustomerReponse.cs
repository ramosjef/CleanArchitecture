using System;

namespace CleanArchitecture.Application.UseCases.GetCustomerUseCase
{
    public class CustomerReponse
    {
        public CustomerReponse(Guid Id, string Name, string DocumentNumber)
        {
            this.Id = Id;
            this.Name = Name;
            this.DocumentNumber = DocumentNumber;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string DocumentNumber { get; private set; }
    }
}
