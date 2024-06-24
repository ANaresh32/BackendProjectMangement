using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinanceManagement.DATA.Models
{
    public class TimeSheets
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        public DateTime Date {  get; set; }
        public decimal HoursWorked { get; set; }
        public string Description { get; set; }
        public string ApprovedBy { get; set; }
        /*public Employee ProjectManagerId { get; set; }
        public string ProjectManagerName { get; set;}*/
    }
}
