namespace MockService.Models;

public class ScheduleGroup
{
    public Guid Id { get; set; }
    public ICollection<OrganizationalUnit> OrganizationalUnits { get; set; }
    public string? Description { get; set; }
    public bool IsValid { get; set; }
    public bool IgNorInCalculations { get; set; }
}