using CleanArchitecture.Domain.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Domain.Core.Entities
{
    public class Paged<TEntity> : IPaged<TEntity>
    {
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int TotalItemsCount { get; set; }
        public IEnumerable<TEntity> Items
        {
            get
            {
                return Items;
            }
            set
            {
                Items = value;
                PageCount = Items.Count();
            }
        }
    }
}
