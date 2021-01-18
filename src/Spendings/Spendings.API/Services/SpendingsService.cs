using Microsoft.EntityFrameworkCore;
using SpendingsApi.Data;
using SpendingsApi.IServices;
using SpendingsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpendingsApi.Services
{
    public class SpendingsService : ISpendingsService

    {
        ApplicationDbContext dbContext;
        public SpendingsService(ApplicationDbContext _db)
        {
            dbContext = _db;
        }
        /// <summary>
        /// Metoda dodająca rekord w tabeli Spendings
        /// </summary>
        /// <param name="spendings"></param>
        /// <returns></returns>
        public async Task<string> AddSpendings(Spendings spendings)
        {
            dbContext.Spendings.Add(spendings);
            await dbContext.SaveChangesAsync();

            return await Task.FromResult("");
           
        }
        /// <summary>
        /// Metoda usuwająca rekord w tabeli Spendings
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteSpendings(int id)
        {

            var spendings = dbContext.Spendings.FirstOrDefault(x => x.idSpendings == id);
            dbContext.Entry(spendings).State = EntityState.Deleted;

            dbContext.SaveChanges();
            return await Task.FromResult("");
        }
        /// <summary>
        /// Metoda pobierająca rekordy z tabeli Spendings - by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Spendings> GetSpendingsByIdAsync(int id)
        {
            var spendings = await dbContext.Spendings.FindAsync(id);

            if (spendings == null)
            {

            }

            return spendings;
        }
        /// <summary>
        /// Metoda pobierająca rekordy z tabeli Spendings
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Spendings>> GetSpendings()
        {
            return await dbContext.Spendings.ToListAsync();
        }
        /// <summary>
        /// Metoda modyfikująca rekord w tabeli Spendings
        /// </summary>
        /// <param name="spendings"></param>
        /// <returns></returns>
        public Spendings UpdateSpendings(Spendings spendings)
        {
            dbContext.Entry(spendings).State = EntityState.Modified;
            dbContext.SaveChanges();
            return spendings;
        }

       

    }
}
