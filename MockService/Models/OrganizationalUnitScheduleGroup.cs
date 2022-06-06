namespace MockService.Models;

public class OrganizationalUnitScheduleGroup
{
    
    public OrganizationalUnitScheduleGroup() {}
    public OrganizationalUnitScheduleGroup(OrganizationalUnit organizationalUnit)
    {
        OrganizationalUnit = organizationalUnit;
    }

    public Guid Id { get; set; }
    public OrganizationalUnit OrganizationalUnit { get; set; }
    public Guid OrganizationalUnitId { get; set; }
}