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
    public class HouseholdsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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

    }
}
