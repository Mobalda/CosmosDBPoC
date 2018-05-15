using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDBPoC.Model;
using Microsoft.AspNetCore.Mvc;
using CosmosDBPoC.Repositories;

namespace CosmosDBPoC.Controllers
{
    [Route("api/[controller]")]
    public class SalesController : Controller
    {
        // GET api/sales
        [HttpGet]
        public async Task<IEnumerable<Sale>> Get()
        {
            var salesRepository = new SalesRepository();
            var sales = await salesRepository.GetSalesAsync();

            return sales;
        }
    }
}
