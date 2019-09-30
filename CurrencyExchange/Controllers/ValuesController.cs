using CurrencyExchange.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CurrencyExchange.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get(string dates, string currency)
        {
            CurrencyExchangeRepository repository = new CurrencyExchangeRepository();
            var result = repository.GetRateStats(dates.Split(',').Select(s => DateTime.Parse(s.Trim())).ToList(), currency.Split('-')[0], currency.Split('>')[1]);
            return result;
        }

    
    }
}
