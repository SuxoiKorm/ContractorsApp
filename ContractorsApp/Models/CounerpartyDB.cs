using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractorsApp.Models
{
    public class CounerpartyDB : LinqToDB.Data.DataConnection
    {
        public CounerpartyDB() : base("CounerpartyDB") { }

        public ITable<Counterparty> Contractors => GetTable<Counterparty>();

    }
}