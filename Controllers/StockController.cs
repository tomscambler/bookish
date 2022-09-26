using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using Microsoft.EntityFrameworkCore;

namespace bookish.Controllers;

public class StockController : Controller
{
    private readonly ILogger<BookController> _logger;

    public StockController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult StockList()
    {
        var context = new BookishContext();
        List<Stock> stock = context.Stock
            .Include(s => s.Book)
            .ToList(); 
        string name = "what ever";
        return View(stock);
    }
}
