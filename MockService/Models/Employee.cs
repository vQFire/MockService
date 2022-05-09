using MockService.Enums;

namespace MockService.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Gender Gender { get; set; }
        public string Initials { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}