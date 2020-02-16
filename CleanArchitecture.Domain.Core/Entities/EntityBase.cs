using System;

namespace CleanArchitecture.Domain.Core.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
    }
}
