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
        List<StockDisplay> stock = context.Books
            .Where(a => a.Stock.Count(b => b.IsAvailable) > 0)
            .Select(b => new StockDisplay(){
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                TotalStock = b.Stock.Count(),
                StockAvailable = b.Stock.Count(a => a.IsAvailable),
            })
            .ToList();
        return View(stock);
    }
}
