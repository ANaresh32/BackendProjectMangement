using System.ComponentModel.DataAnnotations;

namespace FinanceManagement.DATA.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string PasswordHash { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfJoining { get; set; }        
        public Guid ProjectManagerId { get; set; }
       /* public Employee ProjectManagerID { get; set; }*/
        [Required]
        public string EmployeeStatus { get; set; }
        [Required]
        public string SkillSets {  get; set; }
        //public Guid RoleId { get; set; }
        public Role Roles { get; set; }

        // Navigation property for employees managed by this Project Manager
        public ICollection<Employee> ManagedEmployees { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
