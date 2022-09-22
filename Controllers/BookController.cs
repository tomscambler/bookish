using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;

namespace bookish.Controllers;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Book> books = new List<Book>
        {   
            new Book 
            {
                Title = "Dune",
                Author = "Frank Herbert"
            },
            new Book
            {
                Title = "The Art Of War",
                Author = "Sun Tzu"
            },
            new Book
            {
                Title = "Fermat's Last Theorem",
                Author = "Simon Singh"
            }

        };

        return View(books);
    }
}
