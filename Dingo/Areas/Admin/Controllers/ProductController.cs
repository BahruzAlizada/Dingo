using BusinessLayer.Abstract;
using BusinessLayer.Helper;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace Dingo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment env;
        public ProductController(IProductService productService,ICategoryService categoryService,IWebHostEnvironment env)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.env = env;
        }

        #region Index
        public async Task<IActionResult> Index(int page=1)
        {
            double take = 15;
            ViewBag.PageCount = await productService.PageCount(take);
            ViewBag.CurrentPage = page;
            
            List<Product> products = await productService.GetProductsWithPaged((int)take, page);
            return View(products);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await categoryService.GetActiveCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ProductDto productDto,int catId)
        {
            ViewBag.Categories = await categoryService.GetActiveCategories();

            #region Image
            if (productDto.Photo == null)
            {
                ModelState.AddModelError("Photo", "Bu xana boş ola bilməz");
                return View();
            }
            if (!productDto.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Sadəcə jpeg yaxud jpg tipli fayllar");
                return View();
            }
            if (productDto.Photo.IsOlder512Kb())
            {
                ModelState.AddModelError("Photo", "Maksimum 512 Kb");
                return View();
            }
            string folder = Path.Combine(env.WebRootPath, "img", "products");
            productDto.Image = await productDto.Photo.SaveFileAsync(folder);
            #endregion

            productDto.CategoryId = catId;

            await productService.AddAsync(productDto);
            return RedirectToAction("Index");
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Categories = await categoryService.GetActiveCategories();

            if (id == null) return NotFound();
            Product dbProduct = await productService.GetProductAsync(id);
            if (dbProduct == null) return BadRequest();

            ProductDto dbProductDto = new ProductDto
            {
                Id = dbProduct.Id,
                CategoryId = dbProduct.CategoryId,
                Image = dbProduct.Image,
                Name = dbProduct.Name,
                Price = dbProduct.Price,
                IsDeactive = dbProduct.IsDeactive
            };

            return View(dbProductDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id,ProductDto productDto,int catId)
        {
            ViewBag.Categories = await categoryService.GetActiveCategories();

            #region Get
            if (id == null) return NotFound();
            Product dbProduct = await productService.GetProductAsync(id);
            if (dbProduct == null) return BadRequest();

            ProductDto dbProductDto = new ProductDto
            {
                Id = dbProduct.Id,
                CategoryId = dbProduct.CategoryId,
                Image = dbProduct.Image,
                Name = dbProduct.Name,
                Price = dbProduct.Price,
                IsDeactive = dbProduct.IsDeactive
            };
            #endregion

            #region Image
            if (productDto.Photo is not null)
            {
                if (!productDto.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Yalnız şəkil tipli fayllar");
                    return View();
                }
                if (productDto.Photo.IsOlder256Kb())
                {
                    ModelState.AddModelError("Photo", "Maksimum 256Kb");
                    return View();
                }
                string folder = Path.Combine(env.WebRootPath, "img", "products");
                productDto.Image = await productDto.Photo.SaveFileAsync(folder);
                string path = Path.Combine(env.WebRootPath, folder, dbProduct.Image);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

                dbProductDto.Image = productDto.Image;
            }
            else
                productDto.Image = dbProductDto.Image;
            #endregion

            productDto.CategoryId = catId;
            dbProductDto.Id = productDto.Id;
            dbProductDto.Name = productDto.Name;
            dbProductDto.IsDeactive = productDto.IsDeactive;

            await productService.UpdateAsync(productDto);
            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public IActionResult Activity(int id)
        {
            productService.Activity(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
