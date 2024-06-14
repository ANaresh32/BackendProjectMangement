using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.DATA.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string ClientLocation { get; set; }
        public string ReferenceName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
    }
}
