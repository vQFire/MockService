using MockService.Enums;

namespace MockService.Models;

public class ScheduleGroupSchedule
{
    public Guid Id { get; set; }
    public ScheduleType ScheduleType { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}