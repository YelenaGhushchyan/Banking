using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Dal.Entities
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        public decimal DepositMoney { get; set; }
        public decimal WithMoney { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
