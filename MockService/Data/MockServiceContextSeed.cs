using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MockService.Enums;
using MockService.Models;
using NuGet.Protocol;

namespace MockService.Data;

public static class MockServiceContextSeed
{
    public static async Task SeedAsync(MockServiceContext context)
    {
        
        try
        {
            const string basePath = "./Data/SeedData/";
            if (!context.Employees.Any())
            {
                var employeesData = await File.ReadAllTextAsync(basePath + "employees.json");
                var employees = JsonSerializer.Deserialize<List<Employee>>(employeesData);
                foreach (var employee in employees!)
                {
                    employee.DateOfBirth = employee.DateOfBirth.ToUniversalTime();
                    context.Employees.Add(employee);
                }
                await context.SaveChangesAsync();
            }

            if (!context.EmployeeContracts.Any())
            {
                var employeeContractsData = await File.ReadAllTextAsync(basePath + "employeeContracts.json");
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
    }
}