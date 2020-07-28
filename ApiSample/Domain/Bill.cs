using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiSample.Domain
{
    public class Bill
    {
        public Guid Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Title { get; set; }

        public string DateTime { get; set; }

        [JsonIgnore]
        public virtual ICollection<PersonBill> PersonBills { get; set; }
    }
}
