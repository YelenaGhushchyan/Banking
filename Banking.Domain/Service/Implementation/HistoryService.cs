using Banking.Dal;
using Banking.Dal.Entities;
using Banking.Domain.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Service.Implementation
{
    public class HistoryService(AppDbContext context) : IHistoryService
    {
        public async Task<bool> DepositBalance(int customerId, decimal amount)
        {

            var customer = await context.Customers.FindAsync(customerId);
            if(customer == null)
            {
                return false;
            }
            customer.Money += amount;

            var history = new History
            {
                CustomerId = customerId,
                DepositMoney = customer.Money,

            };
            await context.Histories.AddAsync(history);
            await context.SaveChangesAsync();

            return true;
            
        }
        public async Task<bool> WithDrow(int customerId, decimal amount)
        {
            var customer = await context.Customers.FindAsync(customerId);

            if (customer == null || customer.Money < amount)
            {
                return false;
            }
            customer.Money -= amount;
            var history = new History
            {
                CustomerId = customerId,
                DepositMoney = customer.Money,

            };
            await context.Histories.AddAsync(history);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<History>> GetCustomerHistory(int customerId, int pageNumber, int pageSize)
        {
            return await context.Histories
                .Where(h => h.CustomerId == customerId) 
                .OrderByDescending(h => h.Id)          
                .Skip((pageNumber - 1) * pageSize)      
                .Take(pageSize)                         
                .ToListAsync();
        }

    }
}
