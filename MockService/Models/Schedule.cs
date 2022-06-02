using MockService.Enums;

namespace MockService.Models;

public class Schedule
{
    public Guid Id { get; set; }
    public ScheduleType ScheduleType { get; set; }
    public ScheduleGroup ScheduleGroup { get; set; }
    public Guid ScheduleGroupId { get; set; }
    public EmployeeContract EmployeeContract { get; set; }
    public Guid EmployeeContractId { get; set; }
    public DateTime Date { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool HasChanged { get; set; }
}