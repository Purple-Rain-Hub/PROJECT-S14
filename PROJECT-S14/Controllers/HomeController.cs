using System.Diagnostics;
using System.Reflection;
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
                return View("Add", model);
            }
            var modelImg = model.Images.FindAll(x => !string.IsNullOrWhiteSpace(x));

            Article article = new Article()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Thumbnail = model.Thumbnail,
                Images = modelImg
            };
            Articles.Add(article);
            return RedirectToAction("Index");
        }

        [HttpGet("Home/Dettagli/{id:guid}")]
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

        [HttpGet("Home/Modifica/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            var selectedArticle = Articles.FirstOrDefault(x => x.Id == id);
            var articleEdit = new Article()
            {
                Id = selectedArticle.Id,
                Name = selectedArticle.Name,
                Price = selectedArticle.Price,
                Description = selectedArticle.Description,
                Thumbnail = selectedArticle.Thumbnail,
                Images = selectedArticle.Images
            };
            return View(articleEdit);
        }

        [HttpPost]
        public IActionResult SaveEdit(Guid id, Article articleEdit)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", articleEdit);
            }
            var selectedArticle = Articles.FirstOrDefault(x => x.Id == id);
            var articleEditImg = articleEdit.Images.FindAll(x => !string.IsNullOrWhiteSpace(x));
            selectedArticle.Name = articleEdit.Name;
            selectedArticle.Price = articleEdit.Price;
            selectedArticle.Description = articleEdit.Description;
            selectedArticle.Thumbnail = articleEdit.Thumbnail;
            selectedArticle.Images = articleEditImg;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var selectedArticle = Articles.FirstOrDefault(x => x.Id == id);
            Articles.Remove(selectedArticle!);

            return RedirectToAction("Index");
        }
    }
}
