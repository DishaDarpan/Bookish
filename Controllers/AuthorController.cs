using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;

namespace bookish.Controllers;

[Route("authors")]

public class AuthorController : Controller
{
    private readonly ILogger<AuthorController> _logger;

    public AuthorController(ILogger<AuthorController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var context = new BookishContext();
        List<Author> authors = context.Authors.ToList();
        return View(authors);
    }

    [HttpPost("")]
    public IActionResult Create([FromForm] Author newAuthor)
    {   
       var context = new BookishContext();
       var addedEntity = context.Authors.Add(newAuthor);

        context.SaveChanges();

        Author addedAuthor = addedEntity.Entity;

        return RedirectToAction("Index");

    }

     [HttpGet("add")]
    public IActionResult CreateForm()
    {   
        return View();
    }
    
}
