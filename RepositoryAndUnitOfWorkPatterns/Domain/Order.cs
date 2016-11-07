using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWorkPatterns.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool  IsPrepaid  { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
