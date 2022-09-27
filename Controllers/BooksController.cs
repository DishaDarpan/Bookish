using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;

namespace bookish.Controllers;

[Route("books")]

public class BooksController : Controller
{
    private readonly ILogger<BooksController> _logger;

    public BooksController(ILogger<BooksController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var context = new BookishContext();
        List<Book> books = context.Books.ToList();
        return View(books);
    }

    [HttpPost("")]
    public IActionResult Create([FromForm] Book newBook)
    {   
       var context = new BookishContext();
       var addedEntity = context.Books.Add(newBook);

        context.SaveChanges();

        Book addedBook = addedEntity.Entity;

        return RedirectToAction("Index");

    }

     [HttpGet("add")]
    public IActionResult CreateForm()
    {   
        return View();
    }
    
}
