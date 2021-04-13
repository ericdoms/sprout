using System;

namespace SproutSolution.Core.Model
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string TIN { get; set; } 
        public EmployeeType EmployeeType { get; set; }
        public Decimal Days { get; set; }
    }
}
