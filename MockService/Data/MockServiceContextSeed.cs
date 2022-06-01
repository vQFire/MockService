using System.Text.Json;
using MockService.Enums;
using MockService.Models;
using NuGet.Protocol;

namespace MockService.Data;

public static class MockServiceContextSeed
{
    public static void SeedAsync(MockServiceContext context)
    {
        
        try
        {
            string basePath = "./Data/SeedData/";
            if (!context.Employees.Any())
            {
                var employeesData = File.ReadAllText(basePath + "employees.json");
                var employees = JsonSerializer.Deserialize<List<Employee>>(employeesData);
                foreach (var employee in employees!)
                {
                    employee.DateOfBirth = employee.DateOfBirth.ToUniversalTime();
                    context.Employees.Add(employee);
                }
                context.SaveChanges();
            }

            if (!context.EmployeeContracts.Any())
            {
                context.EmployeeContracts.Add(new EmployeeContract()
                {
                    Id = Guid.NewGuid(),
                    Employee = context.Employees.Find(Guid.Parse("d80424f8-d84f-4ab2-9004-dc8e4939e9e4"))!,
                    ScheduleCompetence = "",
                    TrialPeriodEnd = DateTime.Now.ToUniversalTime(),
                    ValidFrom = DateTime.Now.ToUniversalTime(),
                    ValidTo = DateTime.Now.ToUniversalTime(),
                });
                // var employeeContractsData = File.ReadAllText(basePath + "employeeContracts.json");
                // Console.WriteLine(employeeContractsData);
                // var employeeContracts = JsonSerializer.Deserialize<List<EmployeeContract>>(employeeContractsData)!;
                // Console.WriteLine(employeeContracts);
                // foreach (var employeeContract in employeeContracts)
                // {
                //     Console.WriteLine(employeeContract.EmployeeId);
                //     Console.WriteLine("Here");
                //     Console.WriteLine(employeeContract.Employee);
                //     Employee? employee = context.Employees.Find(employeeContract.Employee.Id);
                //     Console.WriteLine(employee);
                //     employeeContract.Employee = employee;
                //     Console.WriteLine(employeeContract.Employee);
                //     context.EmployeeContracts.Add(employeeContract);
                // }

                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
    }
}