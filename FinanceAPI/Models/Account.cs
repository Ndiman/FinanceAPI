using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinanceAPI.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public decimal StartingBalance { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}