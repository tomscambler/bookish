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
    public IActionResult AddBookComfirmed(Book obj)
    {
        var context = new BookContext();
        context.Books.Add(obj);
        context.SaveChanges();
        return RedirectToAction("Index");
    }
    //GET delete
    public IActionResult Delete(int? id)
    {
        var context = new BookContext();
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var target = context.Books.Find(id);
        if (target == null)
        {
            return NotFound();
        }
        return View(target);
    }
    //POST delete

    public IActionResult DeletePost(int? id)
    {
        var context = new BookContext();
        var target = context.Books.Find(id);
        if (target == null)
        {
            return NotFound();
        }
        context.Books.Remove(target);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    //get Edit
    public IActionResult Update(int? id)
    {
        var context = new BookContext();
        var target = context.Books.Find(id);
        if (target == null)
        {
            return NotFound();
        }
        return View(target);
    }
    [HttpPost]
    public IActionResult UpdateComfirmed(Book obj)
    {
        var context = new BookContext();
        if (ModelState.IsValid)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }

    
}
