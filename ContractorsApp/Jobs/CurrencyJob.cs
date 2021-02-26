using ContractorsApp.Models;
using Newtonsoft.Json.Linq;
using Quartz;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Linq;
using LinqToDB;

namespace ContractorsApp.Jobs
{
    public class CurrencyJob : IJob
    {
        private CounerpartyDB db = new CounerpartyDB();
        public async Task Execute(IJobExecutionContext context)
        {                 
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync("https://www.cbr-xml-daily.ru/daily_json.js");
                dynamic data = JObject.Parse(json);
                float USD = data.Valute.USD.Value;
                WriteCurrency(USD);

                System.Diagnostics.Debug.WriteLine(USD);            
            }        
        }
        public void WriteCurrency(float crn)
        {
            Currencies incomeCrn = new Currencies();
            incomeCrn.dateOfCurrency = DateTime.Now;
            incomeCrn.Value = crn;

            using (db)
            {
                db.Insert(incomeCrn);
            }
        }
    }
}