namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int PositionId { get; set; }
        public Position? Position { get; set; }

        public ICollection<Salary> Salaries { get; set; } = new List<Salary>();
        public ICollection<Leave> Leaves { get; set; } = new List<Leave>();
    }
}
