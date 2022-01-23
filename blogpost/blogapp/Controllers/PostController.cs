using blogapp.Data;
using blogapp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace blogapp.Controllers;

public class PostController : Controller
{
    private readonly IPostRepository _repo;

    public PostController(IPostRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Index() => View(_repo.GetAll());

    // [HttpGet]
    // public IActionResult Index(Guid id) => View(_repo.Get(id));

    [HttpGet]
    public IActionResult Create() => View(new Post() { Id = Guid.NewGuid() });

    [HttpPost]
    public IActionResult Create(Post post)
    {
        if(!ModelState.IsValid)
        {
            return  View(post);
        }

        if(_repo.Insert(post))
        {
            return RedirectToAction(nameof(Index));
        }

        return LocalRedirect("/home");
    }
}