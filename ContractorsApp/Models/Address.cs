using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractorsApp.Models
{
    [Table(Name = "Addresses")]
    public class Address
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column(Name = "CPid"), NotNull]
        public int CPid { get; set; }
        [Column(Name = "Address"), NotNull]
        public string BuildingAddress { get; set; }
    }
}