using ControleStorage.Models;
using ControleStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleStorage.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDBContext dbContext;
        public ProductController(ApplicationDBContext context, IWebHostEnvironment environment)
        {
            this.dbContext = context;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var products = dbContext.Products.OrderByDescending(p => p.Id).ToList();

            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            if (productDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", " is not found");
            }
            if (!ModelState.IsValid)
            {
                return View(productDto);
            }
            //Save image file

            string newFileName = Path.GetExtension(productDto.ImageFile!.FileName);  
            //Qayerga yangi kiritilayotgan rasmni saqlash uchun

            string imageFullPath = environment.WebRootPath + "/products/" + newFileName;
            using(var stream = System.IO.File.Create(imageFullPath))
            {
                productDto.ImageFile.CopyTo(stream);
            }

            Product product = new Product()
            {
                Name = productDto.Name,
                Brand = productDto.Brand,
                Category = productDto.Category,
                Price = productDto.Price,
                Description = productDto.Description,
                ImageFileName = newFileName,
                CreatedDate = DateTime.Now,
            };

            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Product");
        }
    }
}
