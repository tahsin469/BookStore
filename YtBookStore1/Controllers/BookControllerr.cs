using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YtBookStore1.Models.Domain;
using YtBookStore1.Repositories.Abstract;

namespace YtBookStore1.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService BookService;
        private readonly IAuthorService authorService;
        private readonly IGenreService genreService;
        private readonly IPublisherService publisherService;

        public BookController(IBookService BookService, IGenreService genreService, IPublisherService publisherService, IAuthorService authorService)
        {
            this.BookService = BookService;
            this.genreService = genreService;
            this.publisherService = publisherService;
            this.authorService = authorService;
        }

        public IActionResult Add()
        {
            var model = new Book();
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString()}).ToList();
            model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString() }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = BookService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";

            return View(model);
        }

        public IActionResult Update(int Id)
        {
            var model = BookService.FindById(Id);
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.Id.ToString(), Selected = a.Id == model.AuthorId }).ToList();
            model.PublisherList = publisherService.GetAll().Select(a => new SelectListItem { Text = a.PublisherName, Value = a.Id.ToString(), Selected = a.Id == model.PublisherId }).ToList();
            model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = BookService.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = BookService.Delete(id);
            return RedirectToAction("Getall");
        }

        public IActionResult GetAll()
        {
            var data = BookService.GetAll();
            return View(data);
        }
    }
}
