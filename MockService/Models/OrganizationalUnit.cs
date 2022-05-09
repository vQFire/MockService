namespace MockService.Models;

public class OrganizationalUnit
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public ICollection<ScheduleGroup> ScheduleGroups { get; set; }
}