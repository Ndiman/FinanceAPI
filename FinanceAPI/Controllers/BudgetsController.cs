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
    public class BudgetsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Inserting Data into Db
        /// <summary>
        /// Add a new Budget to a specific Household
        /// </summary>
        /// <param name="householdId">Household Id</param>
        /// <param name="budgetName">Name of Budget</param>
        /// <param name="budgetDescription">Description</param>
        /// <param name="spendingTarget">Spending Target</param>
        /// <returns>Integer indicating if Insert was successful</returns>
        [Route("AddBudget")]
        [AcceptVerbs("POST")]
        public int AddBudget(int householdId, string budgetName, string budgetDescription, decimal spendingTarget)
        {
            return db.AddBudget(householdId, budgetName, budgetDescription, spendingTarget);
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
        /// <param name="budgetId">Budget Id</param>
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
        public async Task<BudgetItem> GetBudgetItemDetails(int budgetItemId)
        {
            return await db.GetBudgetItemDetails(budgetItemId);
        }

        /// <summary>
        /// Gets Details of a single Budget Item - JSON
        /// </summary>
        /// <param name="budgetItemId">Budget Item Id</param>
        /// <returns></returns>
        [Route("GetBudgetItemDetails/json")]
        public async Task<IHttpActionResult> GetBudgetItemDetailsJson(int budgetItemId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetItemDetails(budgetItemId));
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
    }
}
