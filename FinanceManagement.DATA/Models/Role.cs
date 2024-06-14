using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.DATA.Models
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string Priority { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
