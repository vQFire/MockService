namespace MockService.Dtos;
using MockService.Enums;

public class CreateEmployeeDTO {
    public Gender Gender { get; set; }
    public String Initials { get; set; } = "";
    public String FirstName { get; set; } = "";
    public String Name { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
}