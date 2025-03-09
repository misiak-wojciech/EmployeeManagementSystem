﻿namespace EmployeeManagementSystem.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public LeaveType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveStatus Status { get; set; }
        public string? Reason { get; set; }
    }

    public enum LeaveType
    {
        Paid,
        Unpaid,
        Sick,
        Maternity,
        Other
    }

    public enum LeaveStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
