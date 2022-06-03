namespace MockService.Dtos;
using MockService.Enums;

public class CreateScheduleDTO 
{
    public Guid EmployeeContractId { get; set; }
    public Guid ScheduleGroupId { get; set; }
    public ScheduleType ScheduleType { get; set; }
    public DateTime Date { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}