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
            MenuVM menuVM = new MenuVM
            {
                Categories = await categoryService.GetActiveCategories(),
                Products = await productService.GetActiveProductsWithCategoryAsync()
            };

            return View(menuVM);
        }
        #endregion
    }
}
