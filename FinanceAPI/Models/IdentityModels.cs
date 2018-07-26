using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace FinanceAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Selecting data from Db
        public async Task<Household> GetHousehold(int houseId)
        {
            return await Database.SqlQuery<Household>("GetHouseholdData @houseId",
                new SqlParameter("houseId", houseId)).FirstOrDefaultAsync();
        }

        public async Task<Account> GetAccountDetails(int accountId)
        {
            return await Database.SqlQuery<Account>("GetAccountDetails @accountId",
                new SqlParameter("accountId", accountId)).FirstOrDefaultAsync();
        }

        public async Task<List<Account>> GetAccountsByBank(int bankId)
        {
            return await Database.SqlQuery<Account>("GetAccountsByBank @bankId",
                new SqlParameter("bankId", bankId)).ToListAsync();
        }

        public async Task<List<Account>> GetAccountsByHouse(int houseId)
        {
            return await Database.SqlQuery<Account>("GetAccountsByHouse @houseId",
                new SqlParameter("houseId", houseId)).ToListAsync();
        }

        public async Task<List<Bank>> GetBanks(int houseId)
        {
            return await Database.SqlQuery<Bank>("GetBanks @houseId",
                new SqlParameter("houseId", houseId)).ToListAsync();
        }

        public async Task<List<Budget>> GetBudgets(int houseId)
        {
            return await Database.SqlQuery<Budget>("GetBudgets @houseId",
                new SqlParameter("houseId", houseId)).ToListAsync();
        }

        public async Task<Budget> GetBudgetDetails(int budgetId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDetails @budgetId",
                new SqlParameter("budgetId", budgetId)).FirstOrDefaultAsync();
        }

        public async Task<BudgetItem> GetBudgetItemDetails(int budgetItemId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetails @budgetItemId",
                new SqlParameter("budgetItemId", budgetItemId)).FirstOrDefaultAsync();
        }

        public async Task<List<BudgetItem>> GetBudgetItems(int budgetId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems @budgetId",
                new SqlParameter("budgetId", budgetId)).ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactions(int accountId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactions @accountId",
                new SqlParameter("accountId", accountId)).ToListAsync();
        }

        public async Task<Transaction> GetTransactionDetails(int transactionId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @transactionId",
                new SqlParameter("transactionId", transactionId)).FirstOrDefaultAsync();
        }

        //Inserting data into Db
        public int AddBudget(int householdId, string budgetName, string budgetDescription, decimal spendingTarget)
        {
            return Database.ExecuteSqlCommand("AddBudget @householdId, @budgetName, @budgetDescription, @spendingTarget",
                new SqlParameter("householdId", householdId),
                new SqlParameter("budgetName", budgetName),
                new SqlParameter("budgetDescription", budgetDescription),
                new SqlParameter("spendingTarget", spendingTarget));
        }

        public int AddAccount(int accountTypeId, int bankId, string name, string description, decimal startingBalance)
        {
            return Database.ExecuteSqlCommand("AddAccount @accountTypeId, @bankId, @name, @description, @startingBalance",
                new SqlParameter("accountTypeId", accountTypeId),
                new SqlParameter("bankId", bankId),
                new SqlParameter("name", name),
                new SqlParameter("description", description),
                new SqlParameter("startingBalance", startingBalance));
        }

        public int AddTransaction(int accountId, decimal ammount, string title, string memo, bool reconciled, decimal reconciledAmt, int transactionTypeId)
        {
            return Database.ExecuteSqlCommand("AddTransaction @accountId, @ammount, @title, @memo, @reconciled, @reconciledAmt, @transactionTypeId",
                new SqlParameter("accountId", accountId),
                new SqlParameter("ammount", ammount),
                new SqlParameter("title", title),
                new SqlParameter("memo", memo),
                new SqlParameter("reconciled", reconciled),
                new SqlParameter("reconciledAmt", reconciledAmt),
                new SqlParameter("transactionTypeId", transactionTypeId));
        }
    }
}