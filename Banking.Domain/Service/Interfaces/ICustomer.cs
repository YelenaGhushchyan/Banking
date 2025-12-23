using System;
using System.Collections.Generic;
using System.Linq;
using Banking.Dal.Entities;
using System.Text;
using System.Threading.Tasks;
using Banking.Domain.Model;

namespace Banking.Domain.Service.Interfaces
{
    public interface ICustomer
    {
       Task<Customer> CreateCustomer(string Name, string Email);
    }
}
