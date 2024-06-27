using Microsoft.EntityFrameworkCore;
using Ис_Мебельного_магазина.Domain.Models;

namespace Ис_Мебельного_магазина.Domain.Interactors;

public class EmployeeInteractor
{
    private ApplicationDbContext context;

    public EmployeeInteractor(ApplicationDbContext context)
    {
        this.context = context;
    }
    public void AddEmployee(Employee employee)
    {
        context.Add(employee);
        context.SaveChanges();
    }

    public Employee CreateEmployee(Employee employee)
    {
        try 
        {
            context.Add(employee);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            return null;
        }

        return employee;
    }


    public void RemoveEmployee(Employee employeeId)
    {
        var s = GetEmployee(employeeId);
        if (s is null)
        {
            context.Remove(s);
            context.SaveChanges();
        };
    }

    public void Update(Employee employee) 
    {
        context.Update(employee);
        context.SaveChanges();

    }

    public IQueryable<Employee> GetAll()
    {
        return context.Set<Employee>();
    }

    public Employee? GetEmployee (Employee emloyeeId)
    {
        return context.employees.Find(emloyeeId);
    }

    public List<Employee> GetEmployies()
    {
        IQueryable<Employee> employies = context.employees;

        //categoryes = categoryes.where()
        return employies.ToList();
    }
}
