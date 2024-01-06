using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Dingo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dingo.Controllers
{
	public class MenuController : Controller
	{
		private readonly ICategoryService categoryService;
		private readonly IProductService productService;
        public MenuController(ICategoryService categoryService,IProductService productService)
        {
			this.categoryService = categoryService;
			this.productService = productService;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            using var context = new Context();

            MenuVM menuVM = new MenuVM
            {
                Categories = await context.Categories.Include(x => x.Products).Where(x => !x.IsDeactive).ToListAsync(),
                Products = await context.Products.Include(x=>x.Category).Where(x => !x.IsDeactive).ToListAsync()
            };

            return View(menuVM);
        }
        #endregion
    }
}
