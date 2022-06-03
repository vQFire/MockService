using MockService.Enums;

namespace MockService.Dtos;

public class CreateGroupScheduleDTO
{
    public Guid ScheduleGroupId { get; set; }
    public ScheduleType ScheduleType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}