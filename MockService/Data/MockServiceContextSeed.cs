using System.Text.Json;
using MockService.Enums;
using MockService.Models;

namespace MockService.Data;

public static class MockServiceContextSeed
{
    public static async Task SeedAsync(MockServiceContext context)
    {
        
        try
        {
            string basePath = "./Data/SeedData/";
            if (!context.Employees.Any())
            {
                var employeesData = await File.ReadAllTextAsync(basePath + "employees.json");
                var employees = JsonSerializer.Deserialize<List<Employee>>(employeesData);
                foreach (var employee in employees!)
                {
                    employee!.DateOfBirth = employee.DateOfBirth.ToUniversalTime();
                    context.Employees.Add(employee);
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