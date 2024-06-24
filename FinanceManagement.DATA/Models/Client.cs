using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.DATA.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        //ClientEmailId ,ClientProfile added by nagaraju
        public string ClientEmailId { get; set; }
        public string ClientProfile { get; set; }
        public string ClientLocation { get; set; }
        public string ReferenceName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
       
       
       
    }
}
