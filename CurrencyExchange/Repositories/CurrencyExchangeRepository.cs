using CurrencyExchange.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace CurrencyExchange.Repositories
{
    
    public class CurrencyExchangeRepository
    {
        private string BaseURL = "https://api.exchangeratesapi.io";

        public string GetRateStats(List<DateTime> dates, string baseCurrency, string targetCurrency)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    DateTime minDate = DateTime.MinValue;
                    DateTime maxDate = DateTime.MinValue;
                    double minRate = double.MaxValue;
                    double maxRate = double.MinValue;
                    double avgSum = 0;
                    int avgCount = 0;
                    client.BaseAddress = new Uri(BaseURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = new TimeSpan(0, 30, 0);
                    var task = client.GetAsync("history?start_at=" + dates.Min().ToString("yyyy-MM-dd") + "&end_at=" + dates.Max().ToString("yyyy-MM-dd") + "&symbols=" + targetCurrency + "&base=" + baseCurrency);
                    task.Wait();
                    HttpResponseMessage response = task.Result;
                    ExchangeResult result = JsonConvert.DeserializeObject<ExchangeResult>(response.Content.ReadAsStringAsync().Result);
                    foreach (var i in result.Rates)
                    {
                        DateTime currDateTime = DateTime.Parse(i.Key);
                        if (dates.Contains(currDateTime))
                        {
                            double currRate = 0;
                            if (double.TryParse(i.Value[targetCurrency].ToString(), out currRate))
                            {
                                avgSum += currRate;
                                avgCount++;
                                if (minRate > currRate) { minRate = currRate; minDate = currDateTime; }
                                if (maxRate < currRate) { maxRate = currRate; maxDate = currDateTime; }
                            }

                        }

                    }
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("A min rate of {0} on {1},\nA max rate of {2}, on {3},\nAn average rate of {4}",
                        minRate, minDate.ToString("yyyy-MM-dd"), maxRate, maxDate.ToString("yyyy-MM-dd"), avgSum / avgCount);
                    //NOTE: Return note if some date does not have currency.
                    return sb.ToString();
                }
            }
            catch (Exception e)
            {
                //LOG EXCEPTION!!!!
                return "An error occured, please contact administrator.";
            }
        }
    }
}