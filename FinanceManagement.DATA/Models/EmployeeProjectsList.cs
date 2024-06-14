using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.DATA.Models
{
    public class EmployeeProjectsList
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        public int ProjectBasePrice { get; set; }
        [Required]
        [Display(Name = "Hourly/Monthly")]
        public string ProjectType { get; set; }
        public int TotalPrice { get; set; }
    }
}
