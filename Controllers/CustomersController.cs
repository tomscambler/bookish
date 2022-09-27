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
//     public IActionResult AddStock(int? Id)
//     {
//         var context = new BookishContext();
//         Book? book = context.Books.Find(Id);

//         context.Stock.Add(new Stock()
//         {
//             Book = book,
//             IsAvailable = true
//         });
        
//         context.SaveChanges();
//         return RedirectToAction("StockList");
//     }

//     public IActionResult DeleteStock(int? Id)
//     {
//         var context = new BookishContext();
//         Book? book = context.Books.Find(Id);
//         Stock? stock = context.Stock.FirstOrDefault( stockItem => stockItem.Book==book && stockItem.IsAvailable);
        
//         if(stock!=null)
//         {
//             context.Remove(stock);
//             context.SaveChanges();
//         }
        
//         return RedirectToAction("StockList");
//     }
}
