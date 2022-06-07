using System.Collections.ObjectModel;

namespace MockService.Models;

public class ScheduleGroup
{
    public Guid Id { get; set; }
    public ICollection<OrganizationalUnit> OrganizationalUnits { get; set; }
    public ICollection<Competence> Competences { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Code { get; set; }
    public bool IsValid { get; set; }
    public bool IgnoreInCalculations { get; set; }
}