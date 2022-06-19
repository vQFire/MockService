﻿using System.Text.Json;
using MockService.Models;

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
            await SeedOrganizationalUnitScheduleGroups(context);
            await SeedScheduleGroups(context);
            await SeedScheduleGroupSchedules(context);
            await SeedSchedules(context);
            await LinkScheduleGroupToCompetenceScheduleGroup(context);
            await LinkOrganizationalUnitScheduleGroup(context);
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
                await File.ReadAllTextAsync(BasePath + "competenceScheduleGroups.json");
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

    private static async Task SeedOrganizationalUnitScheduleGroups(MockServiceContext context)
    {
        if (!context.OrganizationalUnitScheduleGroups.Any())
        {
            var organizationalUnitScheduleGroupsData =
                await File.ReadAllTextAsync(BasePath + "organizationalUnitScheduleGroups.json");
            var organizationalUnitScheduleGroups =
                JsonSerializer.Deserialize<List<OrganizationalUnitScheduleGroup>>(organizationalUnitScheduleGroupsData)!;
            foreach (var organizationalUnitScheduleGroup in organizationalUnitScheduleGroups)
            {
                context.OrganizationalUnitScheduleGroups.Add(organizationalUnitScheduleGroup);
            }
            await context.SaveChangesAsync();
        }
    }
    
    private static async Task SeedScheduleGroups(MockServiceContext context)
    {
        if (!context.ScheduleGroup.Any())
        {
            var scheduleGroupsData =
                await File.ReadAllTextAsync(BasePath + "scheduleGroups.json");
            var scheduleGroups =
                JsonSerializer.Deserialize<List<ScheduleGroup>>(scheduleGroupsData)!;
            foreach (var scheduleGroup in scheduleGroups)
            {
                context.ScheduleGroup.Add(scheduleGroup);
            }
            await context.SaveChangesAsync();
        }
    }
    
    private static async Task SeedScheduleGroupSchedules(MockServiceContext context)
    {
        if (!context.ScheduleGroupSchedule.Any())
        {
            var scheduleGroupSchedulesData =
                await File.ReadAllTextAsync(BasePath + "scheduleGroupSchedules.json");
            var scheduleGroupSchedules =
                JsonSerializer.Deserialize<List<ScheduleGroupSchedule>>(scheduleGroupSchedulesData)!;
            foreach (var scheduleGroupSchedule in scheduleGroupSchedules)
            {
                scheduleGroupSchedule.Start = scheduleGroupSchedule.Start.ToUniversalTime();
                scheduleGroupSchedule.End = scheduleGroupSchedule.End.ToUniversalTime();
                context.ScheduleGroupSchedule.Add(scheduleGroupSchedule);
            }
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedSchedules(MockServiceContext context)
    {
        if (!context.Schedule.Any())
        {
            var schedulesData =
                await File.ReadAllTextAsync(BasePath + "schedules.json");
            var schedules =
                JsonSerializer.Deserialize<List<Schedule>>(schedulesData)!;
            foreach (var schedule in schedules)
            {
                schedule.Date = schedule.Date.ToUniversalTime();
                schedule.Start = schedule.Start.ToUniversalTime();
                schedule.End = schedule.End.ToUniversalTime();
                context.Schedule.Add(schedule);
            }
            await context.SaveChangesAsync();
        }
    }

    private static async Task LinkScheduleGroupToCompetenceScheduleGroup(MockServiceContext context)
    {
        // Add Ig3 competence to OD1
        var scheduleGroupOd1 = await context.ScheduleGroup.FindAsync(Guid.Parse("ec1542e0-a2c9-43d0-ab31-357cc8fd6adb"));
        var competenceScheduleGroupIg3 = await context.CompetenceScheduleGroups.FindAsync(Guid.Parse("ec17b921-bfd1-4382-a81b-c69c775409ec"));
        scheduleGroupOd1!.CompetenceScheduleGroups = new List<CompetenceScheduleGroup>();
        scheduleGroupOd1.CompetenceScheduleGroups.Add(competenceScheduleGroupIg3!);
        // Add Niv1 competence to MD1
        var scheduleGroupMd1 = await context.ScheduleGroup.FindAsync(Guid.Parse("3e7f7adb-fc4e-43c8-9600-276434af27c6"));
        var competenceScheduleGroupNiv1 = await context.CompetenceScheduleGroups.FindAsync(Guid.Parse("e196df00-4565-4a29-a218-d329ae6e9bcd"));
        scheduleGroupMd1!.CompetenceScheduleGroups = new List<CompetenceScheduleGroup>();
        scheduleGroupMd1.CompetenceScheduleGroups.Add(competenceScheduleGroupNiv1!);
        
        await context.SaveChangesAsync();
    }

    private static async Task LinkOrganizationalUnitScheduleGroup(MockServiceContext context)
    {
        // Add OD1 schedule group to VVLEINO
        var scheduleGroupOd1 = await context.ScheduleGroup.FindAsync(Guid.Parse("ec1542e0-a2c9-43d0-ab31-357cc8fd6adb"));
        var organizationalUnitScheduleGroupVvleino = await context.OrganizationalUnitScheduleGroups.FindAsync(Guid.Parse("4db34c1c-5654-48fa-b1cd-a4a29e007e75"));
        scheduleGroupOd1!.OrganizationalUnits = new List<OrganizationalUnitScheduleGroup>();
        scheduleGroupOd1.OrganizationalUnits.Add(organizationalUnitScheduleGroupVvleino!);
        // Add MD1 schedule group to LAB Oost
        var scheduleGroupMd1 = await context.ScheduleGroup.FindAsync(Guid.Parse("3e7f7adb-fc4e-43c8-9600-276434af27c6"));
        var organizationalUnitScheduleGroupLabOost = await context.OrganizationalUnitScheduleGroups.FindAsync(Guid.Parse("ac7e15ed-a1b7-456a-b323-9a842eff2ef8"));
        scheduleGroupMd1!.OrganizationalUnits = new List<OrganizationalUnitScheduleGroup>();
        scheduleGroupMd1.OrganizationalUnits.Add(organizationalUnitScheduleGroupLabOost!);
        // Add MD1 schedule group to VVLEINO
        scheduleGroupMd1.OrganizationalUnits.Add(organizationalUnitScheduleGroupVvleino!);
        await context.SaveChangesAsync();
    }

}