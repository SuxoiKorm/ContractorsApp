using ContractorsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using LinqToDB;

namespace ContractorsApp.Controllers
{
    public class CounterpartyController : ApiController
    {
        [HttpGet]
        public List<Counterparty> Get()
        {
            using (var db = new CounerpartyDB())
            {
                var query = from p in db.Contractors
                            orderby p.Id ascending
                            select p;
                return query.ToList();
            }
        }
        [HttpGet]
        public Counterparty Get(int id)
        {
            using (var db = new CounerpartyDB())
            {
                var query = from p in db.Contractors
                            where p.Id == id
                            select p;
                return query.ToList()[0];
            }
        }
        [HttpPost]
        public void Post([FromBody] Counterparty cp)
        {
            using (var db = new CounerpartyDB())
            {
                db.Insert(cp);
            }
        }
        [HttpPut]
        public void Put(int id, [FromBody] Counterparty cp)
        {
            using (var db = new CounerpartyDB())
            {
                db.Contractors.Where(p => p.Id == id).Set(p => p.Name, cp.Name).Set(p => p.Phone, cp.Phone).Update();
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            using (var db = new CounerpartyDB())
            {
                db.Contractors.Where(p => p.Id == id).Delete();
            }
        }        
    }
}