using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractorsApp.Models
{
    [Table(Name = "Contractors")]
    public class Counterparty
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column(Name = "Name"), NotNull]
        public string Name { get; set; }
        [Column(Name = "Phone"), NotNull]
        public string Phone { get; set; }
        public string Address { get; set;}
    }
}