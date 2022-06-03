using System.Collections.ObjectModel;

namespace MockService.Models;

public class ScheduleGroup
{
    public Guid Id { get; set; }
    public IEnumerable<OrganizationalUnitScheduleGroup> OrganizationalUnits { get; set; }
    public IEnumerable<CompetenceScheduleGroup> CompetenceScheduleGroups { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsValid { get; set; }
    public bool IgNorInCalculations { get; set; }
}