using Banking.Dal;
using Banking.Domain.Service.Interfaces;
using System;
using Banking.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Banking.Domain.Service.Implementation
{
    public class CustomerService(AppDbContext context) : ICustomer
    {
        public async Task<Customer> CreateCustomer(string Name,string Email)
        {
            var existing = await context.Customers.AnyAsync(c => c.Email == Email);
            if (existing) { 
                throw new Exception($"there is customer with {Email}");
            }
            var customer = new Customer
            {
                Name = Name,
                Email = Email
            };
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();  
            return customer;
        }
    }
}
