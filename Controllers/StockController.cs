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
        List<StockDisplay> stockDisplay = context.Books
            //.Where(a => a.Stock.Count(b => b.IsAvailable) > 0)
            .Select(b => new StockDisplay(){
                BookId = b.Id,
                Title = b.Title,
                Author = b.Author,
                TotalStock = b.Stock.Count(),
                StockAvailable = b.Stock.Count(a => a.IsAvailable),
            })
            .ToList();
        return View(stockDisplay);
    }
    
    public IActionResult AddStock(int? Id)
    {
        var context = new BookishContext();
        Book? book = context.Books.Find(Id);

        context.Stock.Add(new Stock()
        {
            Book = book,
            IsAvailable = true
        });
        
        context.SaveChanges();
        return RedirectToAction("StockList");
    }

    public IActionResult DeleteStock(int? Id)
    {
        var context = new BookishContext();
        Book? book = context.Books.Find(Id);
        Stock? stock = context.Stock.FirstOrDefault( stockItem => stockItem.Book==book && stockItem.IsAvailable);
        
        if(stock!=null)
        {
            context.Remove(stock);
            context.SaveChanges();
        }
        
        return RedirectToAction("StockList");
    }
}
