namespace MockService.Dtos;

public class EmployeeContractExtensionDTO 
{
    public Guid EmployeeContractID { get; set; }
    public Guid OrganizationalUnitID { get; set; }
    public String Function { get; set; } = "";
    public int LaborMinutesPerWeekMin { get; set; }
    public int LaborMinutesPerWeekMax { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}