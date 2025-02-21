using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PROJECT_S14.Models;

namespace PROJECT_S14.Controllers
{
    public class HomeController : Controller
    {
        private static List<Article> Articles = new();

        public IActionResult Index()
        {
            
            var model = new ArticlesViewModel() { articles = Articles };
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            Articles.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet("Home/Details/{id:guid}")]
        public IActionResult Details(Guid id)
        {
            var selectedArticle = Articles.FirstOrDefault(x => x.Id == id);

            var articleDetails = new Article()
            {
                Name = selectedArticle.Name,
                Price = selectedArticle.Price,
                Description = selectedArticle.Description,
                Thumbnail = selectedArticle.Thumbnail,
                Images = selectedArticle.Images
            };

            return View(articleDetails);
        }
    }
}
