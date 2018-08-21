using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace WebApiStockManage.Controllers
{
    public class StockController : ApiController
    {
        private static int saldo = 0;

        // GET api/values
        /// <summary>
        /// Get the Saldo in the Stock
        /// </summary>
        /// <returns>Returns a int contening Saldo</returns>
        [SwaggerOperation("GetSaldo")]
        public int GetSaldo()
        {
            return saldo;
        }
        
        // PUT api/values/5
        /// <summary>
        /// Make a saldo movment in the Stock
        /// </summary>
        /// <param name="value">the value should be an int and for buying should be + value and - when selling.</param>
        [SwaggerOperation("UpdateSaldo")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Put([FromBody]int value)
        {
            saldo += value;
        }
    }
}
