using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractorsApp.Models
{
    [Table(Name = "Currency")]
    public class Currencies
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column(Name = "Value"), NotNull]
        public float Value { get; set; }
        [Column(Name = "Date"), NotNull]
        public DateTime dateOfCurrency;
    }
}