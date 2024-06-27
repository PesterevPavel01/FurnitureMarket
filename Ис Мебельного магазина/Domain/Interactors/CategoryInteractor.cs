using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using Ис_Мебельного_магазина.Domain.Models;

namespace Ис_Мебельного_магазина.Domain.Interactors;

public class CategoryInteractor 
{
    private ApplicationDbContext context;

    public CategoryInteractor(ApplicationDbContext context)
    {
        this.context = context;
    }

    public void AddCategory(Category Category)
    {
        context.Add(Category);
        context.SaveChanges();

    }
    public void RemoveCategory(Category CategoryId)
    {
        var s  = GetCategory(CategoryId);
        if (s is null)
        {
            context.Remove(s);
            context.SaveChanges();
        }
    }
    public Category CreateCategory(Category category)
    {
        try
        {
            context.Add(category);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            return null;
        }

        return category;
    }
    public IQueryable<Category> GetAll()
    {
        return context.Set<Category>();
    }

    public Category? GetCategory(Category categoryId)
    {
        return context.categories.Find(categoryId);
    }

    public List <Category> GetCategorys()
    {
        IQueryable<Category> categoryes = context.categories;

        //categoryes = categoryes.where()
        return categoryes.ToList();

    }

    public void Update(Category category)
    {
        context.Update(category);
        context.SaveChanges();
    }

  
}
