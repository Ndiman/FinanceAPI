using FinanceAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinanceAPI.Controllers
{
    [RoutePrefix("api/Service")]
    public class AccountsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Add a new Account to a specific Bank
        /// </summary>
        /// <param name="accountTypeId">Account Type Id</param>
        /// <param name="bankId">Bank Id</param>
        /// <param name="name">Account Name</param>
        /// <param name="description">Description</param>
        /// <param name="startingBalance">Starting Balance</param>
        /// <returns>Integer indicating if Insert was successful</returns>
        [Route("AddAccount")]
        [AcceptVerbs("POST")]
        public int AddAccount(int accountTypeId, int bankId, string name, string description, decimal startingBalance)
        {
            return db.AddAccount(accountTypeId, bankId, name, description, startingBalance);
        }

        /// <summary>
        /// Gets Details of a single Account
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <returns></returns>
        [Route("GetAccountDetails")]
        public async Task<Account> GetAccountDetails(int accountId)
        {
            return await db.GetAccountDetails(accountId);
        }

        /// <summary>
        /// Gets Details of a single Account - JSON
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <returns></returns>
        [Route("GetAccountDetails/json")]
        public async Task<IHttpActionResult> GetAccountDetailsJson(int accountId)
        {
            var json = JsonConvert.SerializeObject(await db.GetAccountDetails(accountId));
            return Ok(json);
        }

        /// <summary>
        /// Gets all Accounts in a single Bank
        /// </summary>
        /// <param name="bankId">Bank Id</param>
        /// <returns></returns>
        [Route("GetAccountsByBank")]
        public async Task<List<Account>> GetAccountsByBank(int bankId)
        {
            return await db.GetAccountsByBank(bankId);
        }

        /// <summary>
        /// Gets all Accounts in a single Bank - JSON
        /// </summary>
        /// <param name="bankId">Bank Id</param>
        /// <returns></returns>
        [Route("GetAccountsByBank/json")]
        public async Task<IHttpActionResult> GetAccountsByBankJson(int bankId)
        {
            var json = JsonConvert.SerializeObject(await db.GetAccountsByBank(bankId));
            return Ok(json);
        }

        /// <summary>
        /// Gets all Accounts in a Household
        /// </summary>
        /// <param name="houseId">Household Id</param>
        /// <returns></returns>
        [Route("GetAccountsByHouse")]
        public async Task<List<Account>> GetAccountsByHouse(int houseId)
        {
            return await db.GetAccountsByHouse(houseId);
        }

        /// <summary>
        /// Gets all Accounts in a Household - JSON
        /// </summary>
        /// <param name="houseId">Household Id</param>
        /// <returns></returns>
        [Route("GetAccountsByHouse/json")]
        public async Task<IHttpActionResult> GetAccountsByHouseJson(int houseId)
        {
            var json = JsonConvert.SerializeObject(await db.GetAccountsByHouse(houseId));
            return Ok(json);
        }

        /// <summary>
        /// Gets all Banks in a Household
        /// </summary>
        /// <param name="houseId">House Id</param>
        /// <returns></returns>
        [Route("GetBanks")]
        public async Task<List<Bank>> GetBanks(int houseId)
        {
            return await db.GetBanks(houseId);
        }

        /// <summary>
        /// Gets all Banks in a Household - JSON
        /// </summary>
        /// <param name="houseId">House Id</param>
        /// <returns></returns>
        [Route("GetBanks/json")]
        public async Task<IHttpActionResult> GetBanksJson(int houseId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBanks(houseId));
            return Ok(json);
        }
    }
}
