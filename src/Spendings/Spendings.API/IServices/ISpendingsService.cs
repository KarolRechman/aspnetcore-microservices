using SpendingsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingsApi.IServices
{
    public interface ISpendingsService
    {
        Task<IList<Spendings>> GetSpendings();
        Task<Spendings> GetSpendingsByIdAsync(int id);
        Task<string> AddSpendings(Spendings spendings);
        Spendings UpdateSpendings(Spendings spendings);
        Task<string> DeleteSpendings(int id);



           
    }
}
