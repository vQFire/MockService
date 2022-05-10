namespace MockService.Models;

public class ScheduleGroup
{
    public Guid Id { get; set; }
    public ICollection<OrganizationalUnitScheduleGroup> OrganizationalUnits { get; set; }
    public ICollection<CompetenceScheduleGroup> CompetenceScheduleGroups { get; set; }
    public string? Description { get; set; }
    public bool IsValid { get; set; }
    public bool IgNorInCalculations { get; set; }
}