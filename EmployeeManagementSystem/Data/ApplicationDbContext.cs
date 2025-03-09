using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Employee>(entity =>
            {         

                entity.HasKey(e => e.Id); 

                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Email)
                      .IsRequired();

              
                entity.HasOne(e => e.Department)
                      .WithMany(d => d.Employees)
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);

                
                entity.HasOne(e => e.Position)
                      .WithMany(p => p.Employees)
                      .HasForeignKey(e => e.PositionId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

          
            modelBuilder.Entity<Department>(entity =>
            {              
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Name)
                      .IsRequired()
                      .HasMaxLength(50);
            });

          
            modelBuilder.Entity<Position>(entity =>
            {            

                entity.HasKey(p => p.Id);
                entity.Property(p => p.Title)
                      .IsRequired()
                      .HasMaxLength(50);
            });

           
            modelBuilder.Entity<Salary>(entity =>
            {               

                entity.HasKey(s => s.Id);

                entity.Property(s => s.Amount)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.Property(s => s.PaymentDate)
                      .IsRequired();

                
                entity.HasOne(s => s.Employee)
                      .WithMany(e => e.Salaries)
                      .HasForeignKey(s => s.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

        
            modelBuilder.Entity<Leave>(entity =>
            {
               
                entity.HasKey(l => l.Id);

                entity.Property(l => l.StartDate)
                      .IsRequired();

                entity.Property(l => l.EndDate)
                      .IsRequired();

                entity.Property(l => l.Reason)
                      .HasMaxLength(250);

                
                entity.Property(l => l.Type)
                      .HasConversion<string>()
                      .IsRequired();

                entity.Property(l => l.Status)
                      .HasConversion<string>()
                      .IsRequired();

                
                entity.HasOne(l => l.Employee)
                      .WithMany(e => e.Leaves)
                      .HasForeignKey(l => l.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "IT" },
            new Department { Id = 2, Name = "HR" },
            new Department { Id = 3, Name = "Finance" }
            );

           
            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, Title = "Software Engineer"},
                new Position { Id = 2, Title = "HR Specialist" },
                new Position { Id = 3, Title = "Accountant" }
            );

           
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PositionId = 1, DepartmentId = 1 },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PositionId = 2, DepartmentId = 2 },
                new Employee { Id = 3, FirstName = "Michael", LastName = "Brown", Email = "michael.brown@example.com", PositionId = 3, DepartmentId = 3 }
            );

            
            modelBuilder.Entity<Salary>().HasData(
                new Salary { Id = 1, EmployeeId = 1, Amount = 5000, PaymentDate = new DateTime(2025, 1, 1) },
                new Salary { Id = 2, EmployeeId = 2, Amount = 4000, PaymentDate = new DateTime(2025, 1, 1) },
                new Salary { Id = 3, EmployeeId = 3, Amount = 4500, PaymentDate = new DateTime(2025, 1, 1) }
            );

          
            modelBuilder.Entity<Leave>().HasData(
                new Leave { Id = 1, EmployeeId = 1, Type = LeaveType.Paid, StartDate = new DateTime(2025, 6, 1), EndDate = new DateTime(2025, 6, 10), Status = LeaveStatus.Approved, Reason = "Vacation" },
                new Leave { Id = 2, EmployeeId = 2, Type = LeaveType.Sick, StartDate = new DateTime(2025, 3, 15), EndDate = new DateTime(2025, 3, 20), Status = LeaveStatus.Pending, Reason = "Flu" },
                new Leave { Id = 3, EmployeeId = 3, Type = LeaveType.Unpaid, StartDate = new DateTime(2025, 9, 5), EndDate = new DateTime(2025, 9, 12), Status = LeaveStatus.Rejected, Reason = "Personal reasons" }
            );
        }
    }
    
}
