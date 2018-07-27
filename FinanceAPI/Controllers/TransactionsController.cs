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
    public class TransactionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Add a new Transaction to a specific Account
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <param name="ammount">Amount of Transaction</param>
        /// <param name="title">Title</param>
        /// <param name="memo">Memo</param>
        /// <param name="reconciled">Is the Transaction Reconciled?</param>
        /// <param name="reconciledAmt">Reconciled Amount</param>
        /// <param name="transactionTypeId">Type of Transaction</param>
        /// <param name="budgetId">Budget Id</param>
        /// <returns>Integer indicating if Insert was successful</returns>
        [Route("AddTransaction")]
        [AcceptVerbs("POST")]
        public int AddTransaction(int accountId, decimal ammount, string title, string memo, bool reconciled, decimal reconciledAmt, int transactionTypeId, int budgetId)
        {
            return db.AddTransaction(accountId, ammount, title, memo, reconciled, reconciledAmt, transactionTypeId, budgetId);
        }

        /// <summary>
        /// Gets all Transactions in a single Account
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <returns></returns>
        [Route("GetTransactions")]
        public async Task<List<Transaction>> GetTransactions(int accountId)
        {
            return await db.GetTransactions(accountId);
        }

        /// <summary>
        /// Gets all Transactions in a single Account - JSON
        /// </summary>
        /// <param name="accountId">Account Id</param>
        /// <returns></returns>
        [Route("GetTransactions/json")]
        public async Task<IHttpActionResult> GetTransactionsJson(int accountId)
        {
            var json = JsonConvert.SerializeObject(await db.GetTransactions(accountId));
            return Ok(json);
        }

        /// <summary>
        /// Gets all Details in a single Transaction
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns></returns>
        [Route("GetTransactionDetails")]
        public async Task<Transaction> GetTransactionDetails(int transactionId)
        {
            return await db.GetTransactionDetails(transactionId);
        }

        /// <summary>
        /// Gets all Details in a single Transaction - JSON
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns></returns>
        [Route("GetTransactionDetails/json")]
        public async Task<IHttpActionResult> GetTransactionDetailsJson(int transactionId)
        {
            var json = JsonConvert.SerializeObject(await db.GetTransactionDetails(transactionId));
            return Ok(json);
        }
    }
}
