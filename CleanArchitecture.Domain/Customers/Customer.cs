using CleanArchitecture.Domain.Core.Entities;
using System;

namespace CleanArchitecture.Domain.Customers
{
    public class Customer : EntityBase
    {
        public Customer(Guid Id, string Name, string DocumentNumber)
        {
            this.Id = Id;
            this.Name = Name;
            this.DocumentNumber = DocumentNumber;
        }

        public Customer(string Name, string DocumentNumber)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.DocumentNumber = DocumentNumber;
        }

        public string Name { get; private set; }
        public string DocumentNumber { get; private set; }
    }
}
