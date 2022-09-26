using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using Microsoft.EntityFrameworkCore;

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
        var context = new BookContext();
        List<Book> books = context.Books
            .ToList();

        return View(books);
    }
    // get book
    public IActionResult AddBook()
    {
        return View();
    }
    // post book
    [HttpPost]
    public IActionResult AddBookComfirmed(Book book)
    {
        var context = new BookContext();
        context.Books.Add(book);
        context.SaveChanges();
        return RedirectToAction("Index");
    }
    //GET delete
    public IActionResult Delete(Book book)
    {
        var context = new BookContext();
        if (book.Id == 0)
        {
            return NotFound();
        }
        var target = context.Books.Find(book.Id);
        if (target == null)
        {
            return NotFound();
        }
        return View(target);
    }
    //POST delete

    public IActionResult DeleteConfirm(Book book)
    {
        var context = new BookContext();
        context.Remove(book);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    //get Edit
    public IActionResult Update(Book book)
    {
        var context = new BookContext();
        var target = context.Books.Find(book.Id);
        if (target == null)
        {
            return NotFound();
        }
        return View(target);
    }

   public IActionResult UpdateConfirm(Book book)
    {
        var context = new BookContext();
        context.Update(book);
        context.SaveChanges();
        return RedirectToAction("Index");
    }
}
