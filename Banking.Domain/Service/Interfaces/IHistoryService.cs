using Banking.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Service.Interfaces
{
    public interface IHistoryService
    {
        Task<bool> DepositBalance(int customerId, decimal amount);
        Task<bool> WithDrow(int customerId, decimal amount);
        Task<IEnumerable<History>> GetCustomerHistory(int customerId, int pageNumber, int pageSize);
    }
}
