namespace MockService.Models;

public class EmployeeContractExtension
{
    public Guid Id { get; set; }
    public EmployeeContract EmployeeContract { get; set; }
    public OrganizationalUnit OrganizationalUnit { get; set; }
    public string Function { get; set; } = string.Empty;
    public int LaborMinutesPerWeekMin { get; set; }
    public int LaborMinutesPerWeekMax { get; set; }
    public DateTime validFrom { get; set; }
    public DateTime validTo { get; set; }
}