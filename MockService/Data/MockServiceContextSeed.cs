using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MockService.Enums;
using MockService.Models;
using NuGet.Protocol;

namespace MockService.Data;

public static class MockServiceContextSeed
{
    private const string BasePath = "./Data/SeedData/";

    public static async Task SeedAsync(MockServiceContext context)
    {
        try
        {
            await SeedEmployees(context);
            await SeedOrganizationalUnits(context);
            await SeedCompetences(context);
            await SeedEmployeeContracts(context);
            await SeedEmployeeContractCompetences(context);
            await SeedCompetenceScheduleGroups(context);
            await SeedEmployeeContractExtensions(context);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
    }



    private static async Task SeedEmployees(MockServiceContext context)
    {
        if (!context.Employees.Any())
        {
            var employeesData = await File.ReadAllTextAsync(BasePath + "employees.json");
            var employees = JsonSerializer.Deserialize<List<Employee>>(employeesData);
            foreach (var employee in employees!)
            {
                employee.DateOfBirth = employee.DateOfBirth.ToUniversalTime();
                context.Employees.Add(employee);
            }

            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedOrganizationalUnits(MockServiceContext context)
    {
        if (!context.OrganizationalUnits.Any())
        {
            var organizationalUnitsData = await File.ReadAllTextAsync(BasePath + "organizationalUnits.json");
            var organizationalUnits = JsonSerializer.Deserialize<List<OrganizationalUnit>>(organizationalUnitsData);
            foreach (var organizationalUnit in organizationalUnits!)
            {
                context.OrganizationalUnits.Add(organizationalUnit);
            }

            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedCompetences(MockServiceContext context)
    {
        if (!context.Competences.Any())
        {
            var competencesData = await File.ReadAllTextAsync(BasePath + "competences.json");
            var competences = JsonSerializer.Deserialize<List<Competence>>(competencesData);
            foreach (var competence in competences!)
            {
                context.Competences.Add(competence);
            }

            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedEmployeeContracts(MockServiceContext context)
    {
        if (!context.EmployeeContracts.Any())
        {
            var employeeContractsData = await File.ReadAllTextAsync(BasePath + "employeeContracts.json");
            var employeeContracts = JsonSerializer.Deserialize<List<EmployeeContract>>(employeeContractsData)!;
            foreach (var employeeContract in employeeContracts)
            {
                employeeContract.ValidFrom = employeeContract.ValidFrom.ToUniversalTime();
                employeeContract.ValidTo = employeeContract.ValidTo.ToUniversalTime();
                if (employeeContract.TrialPeriodEnd.HasValue)
                {
                    employeeContract.TrialPeriodEnd = employeeContract.TrialPeriodEnd.Value.ToUniversalTime();
                }

                context.EmployeeContracts.Add(employeeContract);
            }

            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedEmployeeContractCompetences(MockServiceContext context)
    {
        if (!context.EmployeeContractCompetences.Any())
        {
            var employeeContractCompetencesData =
                await File.ReadAllTextAsync(BasePath + "employeeContractCompetences.json");
            var employeeContractCompetences =
                JsonSerializer.Deserialize<List<EmployeeContractCompetence>>(employeeContractCompetencesData)!;
            foreach (var employeeContractCompetence in employeeContractCompetences)
            {
                employeeContractCompetence.validFrom = employeeContractCompetence.validFrom.ToUniversalTime();
                employeeContractCompetence.validTo = employeeContractCompetence.validTo.ToUniversalTime();
                context.EmployeeContractCompetences.Add(employeeContractCompetence);
            }

            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedCompetenceScheduleGroups(MockServiceContext context)
    {
        if (!context.CompetenceScheduleGroups.Any())
        {
            var competenceScheduleGroupsData =
                await File.ReadAllTextAsync(BasePath + "employeeContractCompetences.json");
            var competenceScheduleGroups =
                JsonSerializer.Deserialize<List<CompetenceScheduleGroup>>(competenceScheduleGroupsData)!;
            foreach (var competenceScheduleGroup in competenceScheduleGroups)
            {
                context.CompetenceScheduleGroups.Add(competenceScheduleGroup);
            }

            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedEmployeeContractExtensions(MockServiceContext context)
    {
        if (!context.EmployeeContractExtensions.Any())
        {
            var employeeContractExtensionsData =
                await File.ReadAllTextAsync(BasePath + "employeeContractExtensions.json");
            var employeeContractExtensions =
                JsonSerializer.Deserialize<List<EmployeeContractExtension>>(employeeContractExtensionsData)!;
            foreach (var employeeContractExtension in employeeContractExtensions)
            {
                employeeContractExtension.validFrom = employeeContractExtension.validFrom.ToUniversalTime();
                employeeContractExtension.validTo = employeeContractExtension.validTo.ToUniversalTime();
                context.EmployeeContractExtensions.Add(employeeContractExtension);
            }
            await context.SaveChangesAsync();
        }
    }

}