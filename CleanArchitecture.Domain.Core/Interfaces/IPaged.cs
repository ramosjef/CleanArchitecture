using System.Collections.Generic;

namespace CleanArchitecture.Domain.Core.Interfaces
{
    public interface IPaged<T>
    {
        int Page { get; set; }
        int PageCount { get; set; }
        int TotalItemsCount { get; set; }
        IEnumerable<T> Items { get; set; }
    }
}
