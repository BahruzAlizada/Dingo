using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        #region Index
        public IActionResult Index()
        {
            List<Category> categories = categoryService.GetCategories();
            return View(categories);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(CategoryDto categoryDto)
        {
            bool result = categoryService.GetCategories().Any(x => x.Name == categoryDto.Name);
            if (result)
            {
                ModelState.AddModelError("Name", "Bu adda kateqoriya mövcuddur");
                return View();
            }

            categoryService.Add(categoryDto);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Category dbCat = categoryService.GetCategory(id);
            if (dbCat == null) return BadRequest();

            CategoryDto dbCatDto = new CategoryDto
            {
                Id = dbCat.Id,
                Name = dbCat.Name,
                IsDeactive = dbCat.IsDeactive
            };

            return View(dbCatDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int? id,CategoryDto categoryDto)
        {
            #region Get
            if (id == null) return NotFound();
            Category dbCat = categoryService.GetCategory(id);
            if (dbCat == null) return BadRequest();

            CategoryDto dbCatDto = new CategoryDto
            {
                Id = dbCat.Id,
                Name = dbCat.Name,
                IsDeactive = dbCat.IsDeactive
            };
            #endregion

            bool result = categoryService.GetCategories().Any(x => x.Name == categoryDto.Name && x.Id !=id);
            if (result)
            {
                ModelState.AddModelError("Name", "Bu adda kateqoriya mövcuddur");
                return View();
            }

            dbCatDto.Id = categoryDto.Id;
            dbCatDto.Name = categoryDto.Name;
            dbCatDto.IsDeactive = categoryDto.IsDeactive;

            categoryService.Update(categoryDto);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
        {
            categoryService.Activity(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
