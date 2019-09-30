using CurrencyExchange.Models;
using CurrencyExchange.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace CurrencyExchange.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //CurrencyExchangeRepository repository = new CurrencyExchangeRepository();
            //var aa = repository.GetRateStats((new DateTime[3] { new DateTime(2019, 01, 01), new DateTime(2019, 01, 02), new DateTime(2019, 01, 03) }).ToList(), "USD", "CAD");
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
