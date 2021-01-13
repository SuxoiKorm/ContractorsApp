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
            //С одной таблицей
            /*using (var db = new CounerpartyDB())
            {
                var query = from p in db.Contractors
                            orderby p.Id ascending
                            select p;
                return query.ToList();
            }*/
            //С двумя таблицами
            using (var db = new CounerpartyDB())
            {
                var query = from c in db.Contractors
                            from p in db.Addresses.Where(q => q.CPid == c.Id).DefaultIfEmpty()
                            orderby c.Id ascending
                            select new Counterparty
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Phone = c.Phone,
                                Address = p.BuildingAddress,
                            };
                return query.ToList();
            }
        }
        [HttpGet]
        public Counterparty Get(int id)
        {
            using (var db = new CounerpartyDB())
            {
                var query = from c in db.Contractors
                            from p in db.Addresses.Where(q => q.CPid == c.Id).DefaultIfEmpty()
                            where c.Id == id
                            orderby c.Id ascending
                            select new Counterparty
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Phone = c.Phone,
                                Address = p.BuildingAddress,
                            };              
                return query.ToList()[0];
            }
        }
        [HttpPost]
        public void Post([FromBody] Counterparty cp)
        {
            using (var db = new CounerpartyDB())
            {
                cp.Id = db.InsertWithInt32Identity(cp);
                db.Addresses
                    .Value(c => c.BuildingAddress, cp.Address)
                    .Value(c=> c.CPid, cp.Id)
                    .Insert();
            }
        }
        [HttpPut]
        public void Put(int id, [FromBody] Counterparty cp)
        {
            using (var db = new CounerpartyDB())
            {              
                db.Contractors
                    .Where(p => p.Id == id)
                    .Set(p => p.Name, cp.Name)
                    .Set(p => p.Phone, cp.Phone)
                    .Update();
                db.Addresses
                    .Where(c => c.CPid == id)
                    .Set(c => c.BuildingAddress, cp.Address)
                    .Update();
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            using (var db = new CounerpartyDB())
            {
                db.Contractors.Where(p => p.Id == id).Delete();
                db.Addresses.Where(c => c.CPid == id).Delete();
            }
        }        
    }
}