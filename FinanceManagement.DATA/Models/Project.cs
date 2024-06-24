using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinanceManagement.DATA.Models
{
    public class Project
    {
        public Guid id {  get; set; }
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
       // public Guid? EmployeeId { get; set; }
        //public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectRefId { get; set; }//added by nagaraju
        public string ClientEmail { get; set; }
       // public Guid ClientId { get; set; }
        // ProjectType,Progress fields  added by nagaraju
        public string ProjectType { get; set; }
        // string to int changed by nagaraju
        public int Progress { get; set; }
        public int TeamSize { get; set; }
        //added ProjectManager by nagaraju
        public string ProjectManager { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
       // public Guid CID { get; set; }
        //public Client Client { get; set; }
    }
}
