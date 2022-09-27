using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookish.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
        List<Book> books = context
                                .Books
                                .Include(b => b.Authors)
                                .ToList();
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
        var context = new BookishContext();
        List<Author> authors = context.Authors.ToList();
        List<SelectListItem> selectListAuthors = 
            authors.Select(
                a => new SelectListItem { Value = a.id.ToString(), Text = a.Name }
            )
            .ToList();
        ViewBag.Authors = selectListAuthors;
        return View();
    }
    
}
