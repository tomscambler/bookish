using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using Microsoft.EntityFrameworkCore;

namespace bookish.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var context = new BookishContext();
        List<Customer> customerList = context.Customers
            .OrderByDescending( b => b.Id )
            .ToList();

        return View(customerList);
    }

    
    public IActionResult AddCustomer()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddCustomerComfirmed(Customer customer)
    {
        var context = new BookishContext();
        context.Customers.Add(customer);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult ViewBooks(int? Id)
    {
        var context = new BookishContext();
        Customer? customer = context.Customers.Find(Id);

        List<Stock> stock = context.Stock
            .Where(s => s.Customer==customer)
            .Include(s => s.Book)
            .ToList();
        ViewBag.customerName = customer.Name;
        ViewBag.customerEmail = customer.Email;
        return View(stock);
    }
}
