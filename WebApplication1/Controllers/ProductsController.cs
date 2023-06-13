using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Commands.Categories;
using WebApplication1.DataBase.Interfaces;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers.Authenticated
{
    public class ProductsController : Controller
    {
        private readonly IDataBaseContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public ProductsController(IDataBaseContext context, IWebHostEnvironment appEnvironment)
            => (_context, _appEnvironment) = (context, appEnvironment);

        public IActionResult All() => View();

        public IActionResult Add()
        {
            var categories = _context.Categories.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.CategoryId.ToString(),
            });

            var add = new AddProductModel();

            add.Categories = categories;

            return View(add);
        }

        public IActionResult Get(Guid id) 
        {
            var userId = Guid.Parse(HttpContext.User?.FindFirst("id")?.Value ?? Guid.NewGuid().ToString());

            var product = _context
                .Products
                .First(t => t.Id == id)
                .Adapt<ProductInfoDto>();

            var images = _context
                .ProductAndImages
                .Where(i => i.ProductId == product.Id)
                .Join(
                    _context.Images,
                    u => u.ImageId,
                    v => v.Id,
                    (u, v) => v.FileName)
                .ToArray();

            product.Images = images;

            product.IsFavorite = _context
                .Favorites
                .Any(e => 
                    e.UserId == userId &&
                    e.ProductId == id);

            product.IsProductInBasket = _context
                .Baskets
                .Any(w => 
                    w.ProductId == id && 
                    w.UserId == userId);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductModel addProductModel)
        {
            Console.WriteLine(addProductModel.CategoryId);

            var wrapper = new ImageDto()
            {
                FileName = addProductModel.WrapperImage.FileName,
            };

            _context.Images.Add(wrapper);

            var images = new List<ImageDto>();

            addProductModel.Photos.ToList().ForEach(photo =>
            {
                images.Add(new ImageDto()
                {
                    FileName = photo.FileName
                });
            });

            _context.Images.AddRange(images);

            CategoryDto category = _context.Categories
                    .First(y => y.CategoryId == Guid.Parse(addProductModel.CategoryId));

            //TODO: Применить Mapster
            var product = new ProductDto()
            {
                Name = addProductModel.Name,
                Description = addProductModel.Description,
                Composition = addProductModel.Composition,
                Price = addProductModel.Price,
                Count = addProductModel.Count,
                CategoryId = Guid.Parse(addProductModel.CategoryId),
                WrapperImage = wrapper.FileName,
                Category = category,
            };

            category.ProductDtos
                ?.Add(product);

            _context.Products.Add(product);

            images.ForEach(image =>
            {
                var imageItem = new ProductAndImageDto()
                {
                    ImageId = image.Id,
                    ProductId = product.Id
                };

                _context.ProductAndImages.Add(imageItem);
            });

            await _context.SaveAsync();

            string path = $"/Uploads/{addProductModel.WrapperImage.FileName}";

            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await addProductModel.WrapperImage.CopyToAsync(fileStream);
            }

            foreach (var photo in addProductModel.Photos.ToList())
            {
                path = $"/Uploads/{photo.FileName}";

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }
            }

            return Redirect("/");
        }

        /// <summary>
        /// Обработчик запроса на получение списка товаров
        /// </summary>
        /// <returns>List<ProductForViewDto></returns>
        public List<ProductForViewDto> GetAll() 
        {
            // инициализируем команду на получение всех товаров
            var gettingProductList = new AllProductCommand(_context);
            // выполняем команду
            gettingProductList.Execute();

            // Возвращяем готовый список товаров
            return gettingProductList.ReadyList;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id) 
        {
            _context
                .Products
                .Remove(_context
                    .Products
                    .First(p => p.Id == id));

            await _context.SaveAsync();

            return Ok();
        }

        /// <summary>
        /// Обработчик обновления информации о товаре
        /// </summary>
        /// <param name="update">данные для обновления</param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto update) 
        {
            // Получение товара по его id
            var product = _context
                .Products
                .FirstOrDefault(prod => prod.Id == update.Id);

            // если товар не найден сообщаем об этом 
            if (product == null)
                return NotFound();

            // Изменяем данные товара на новые
            product.Name = update.Name;
            product.CategoryId = update.CategoryId;
            product.Description = update.Description;
            product.Composition = update.Composition;
            product.Price = update.Price;
            product.Count = update.Count;

            // сохранение данных в БД
            await _context.SaveAsync();

            // сообщение об успешном завершении
            return Ok();
        }
    }
}