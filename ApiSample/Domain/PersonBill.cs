using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.Domain
{
    public class PersonBill
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }

        public Guid BillId { get; set; }

        public Person Person { get; set; }

        public Bill Bill { get; set; }
    }
}
