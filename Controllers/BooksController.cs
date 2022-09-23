using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;

namespace bookish.Controllers;

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

    [HttpGet]
    public IActionResult Add()
    {   
        return View();
    }

    [HttpPost]
    public IActionResult Add(string title, string author, string imageUrl)
    {   
        using (var context = new BookishContext()) {
            var book = new Book(title, author, imageUrl);

            context.Books.Add(book);
            context.SaveChanges();                
            }
        return View();
    }

    
}
