using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyExchange.Models
{
    public class ExchangeResult
    {
        public JObject Rates { get; set; }
        public DateTime Start_at { get; set; }
        public DateTime End_at { get; set; }
        public String Base { get; set; }
    }
}