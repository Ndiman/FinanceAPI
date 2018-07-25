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
    public class ServiceController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Selecting data from Db
        /// <summary>
        /// Gets Household Data
        /// </summary>
        /// <param name="houseId">Household Id</param>
        /// <returns></returns>
        [Route("GetHousehold")]
        public async Task<Household> GetHousehold(int houseId)
        {
            return await db.GetHousehold(houseId);
        }

        /// <summary>
        /// Gets Household Data - JSON
        /// </summary>
        /// <param name="houseId">Household Id</param>
        /// <returns></returns>
        [Route("GetHousehold/json")]
        public async Task<IHttpActionResult> GetHouseholdJson(int houseId)
        {
            var json = JsonConvert.SerializeObject(await db.GetHousehold(houseId));
            return Ok(json);
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
        /// <param name="accountId"></param>
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

        /// <summary>
        /// Gets all Budgets in a Household
        /// </summary>
        /// <param name="houseId">Household Id</param>
        /// <returns></returns>
        [Route("GetBudgets")]
        public async Task<List<Budget>> GetBudgets(int houseId)
        {
            return await db.GetBudgets(houseId);
        }

        /// <summary>
        /// Gets all Budgets in a Household - JSON
        /// </summary>
        /// <param name="houseId">Household Id</param>
        /// <returns></returns>
        [Route("GetBudgets/json")]
        public async Task<IHttpActionResult> GetBudgetsJson(int houseId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgets(houseId));
            return Ok(json);
        }

        /// <summary>
        /// Gets Details of a single Budget
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns></returns>
        [Route("GetBudgetDetails")]
        public async Task<Budget> GetBudgetDetails(int budgetId)
        {
            return await db.GetBudgetDetails(budgetId);
        }

        /// <summary>
        /// Gets Details of a single Budget - JSON
        /// </summary>
        /// <param name="budgetId">Budget Id</param>
        /// <returns></returns>
        [Route("GetBudgetDetails/json")]
        public async Task<IHttpActionResult> GetBudgetDetailsJson(int budgetId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetDetails(budgetId));
            return Ok(json);
        }

        /// <summary>
        /// Gets Details of a single Budget Item
        /// </summary>
        /// <param name="budgetItemId">Budget Item Id</param>
        /// <returns></returns>
        [Route("GetBudgetItemDetails")]
        public async Task<Budget> GetBudgetItemDetails(int budgetItemId)
        {
            return await db.GetBudgetDetails(budgetItemId);
        }

        /// <summary>
        /// Gets Details of a single Budget Item - JSON
        /// </summary>
        /// <param name="budgetItemId">Budget Item Id</param>
        /// <returns></returns>
        [Route("GetBudgetItemDetails/json")]
        public async Task<IHttpActionResult> GetBudgetItemDetailsJson(int budgetItemId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetDetails(budgetItemId));
            return Ok(json);
        }

        /// <summary>
        /// Gets all Budget Items in a single Budget
        /// </summary>
        /// <param name="budgetId">Budget Id</param>
        /// <returns></returns>
        [Route("GetBudgetItems")]
        public async Task<List<BudgetItem>> GetBudgetItems(int budgetId)
        {
            return await db.GetBudgetItems(budgetId);
        }

        /// <summary>
        /// Gets all Budget Items in a single Budget - JSON
        /// </summary>
        /// <param name="budgetId">Budget Id</param>
        /// <returns></returns>
        [Route("GetBudgetItems/json")]
        public async Task<IHttpActionResult> GetBudgetItemsJson(int budgetId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetItems(budgetId));
            return Ok(json);
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


        //Inserting Data into Db
        /// <summary>
        /// Add a new Budget to a specific Household
        /// </summary>
        /// <param name="householdId">Household Id</param>
        /// <param name="budgetName">Name of Budget</param>
        /// <param name="budgetDescription">Description</param>
        /// <param name="spendingTarget">Spending Target</param>
        /// <param name="currentBalance">Current Balance</param>
        /// <returns>Integer indicating if Insert was successful</returns>
        [Route("AddBudget")]
        [AcceptVerbs("GET")]
        public int AddBudget(int householdId, string budgetName, string budgetDescription, decimal spendingTarget, decimal currentBalance)
        {
            return db.AddBudget(householdId, budgetName, budgetDescription, spendingTarget, currentBalance);
        }

        /// <summary>
        /// Add a new Account to a specific Bank
        /// </summary>
        /// <param name="accountTypeId">Account Type Id</param>
        /// <param name="bankId">Bank Id</param>
        /// <param name="name">Account Name</param>
        /// <param name="description">Description</param>
        /// <param name="startingBalance">Starting Balance</param>
        /// <param name="currentBalance">Current Balance</param>
        /// <returns>Integer indicating if Insert was successful</returns>
        [Route("AddAccount")]
        [AcceptVerbs("GET")]
        public int AddAccount(int accountTypeId, int bankId, string name, string description, decimal startingBalance, decimal currentBalance)
        {
            return db.AddAccount(accountTypeId, bankId, name, description, startingBalance, currentBalance);
        }

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
        /// <returns>Integer indicating if Insert was successful</returns>
        [Route("AddTransaction")]
        [AcceptVerbs("GET")]
        public int AddTransaction(int accountId, decimal ammount, string title, string memo, bool reconciled, decimal reconciledAmt, int transactionTypeId)
        {
            return db.AddTransaction(accountId, ammount, title, memo, reconciled, reconciledAmt, transactionTypeId);
        }

    }
}
