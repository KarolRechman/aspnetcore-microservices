using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendingsApi.Data;
using SpendingsApi.IServices;
using SpendingsApi.Models;

namespace SpendingsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpendingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ISpendingsService spendingsService { get; }
        public SpendingsController(ISpendingsService _spendingsService)
            
        {
            spendingsService = _spendingsService;
        }

        
        /// <summary>
        /// metoda obsługująca request GET dla api/Spendings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<Spendings>> GetSpendings()
        {
            return await spendingsService.GetSpendings();
        }

       
        /// <summary>
        /// metoda obsługująca request GET dla wybranego Id - api/Spendings
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Spendings> GetSpendings(int id)
        {
            return await spendingsService.GetSpendingsByIdAsync(id);

            
        }

        /// <summary>
        /// metoda obsługująca request PUT dla wybranego Id - api/Spendings
        /// </summary>
        /// <param name="spendings"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public  Spendings PutSpendings([FromBody]Spendings spendings)
        {
            return  spendingsService.UpdateSpendings(spendings);
        }

       


        /// <summary>
        /// metoda obsługująca request POST dla api/Spendings
        /// </summary>
        /// <param name="spendings"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task <String> PostSpendings([FromBody] Spendings spendings)
        {
            return await spendingsService.AddSpendings(spendings);
        }

        /// <summary>
        ///  metoda obsługująca request DELETE dla wybranego Id - api/Spendings
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<String> DeleteSpendings(int id)
        {
            return await spendingsService.DeleteSpendings(id);
        }

        /// <summary>
        /// metoda sprawdzająca czy rekord istnieje
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        private bool SpendingsExists(int id)
        {
            return _context.Spendings.Any(e => e.idSpendings == id);
        }
    }
}
