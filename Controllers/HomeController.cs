using System.Data;
using System.Diagnostics;
using Dapper;
using MenuSistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MenuSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbConnection _connection;

        public HomeController(IDbConnection connection)
        {
            _connection = connection;
        }

        public IActionResult Index()
        {
            var categoryList = _connection.Query<Category>("SELECT * FROM Category").ToList();
            var menuLeftJoin = _connection.Query<MenuLeftJoinCategory>("SELECT * FROM Menu LEFT JOIN Category ON Menu.CategoryId = Category.Id").ToList();
            var categorySum = _connection.Query<MenuCategoryCount>
            (
                @"SELECT Menu.CategoryId,Category.CategoryName,COUNT(Menu.MenuId) AS MenuSayisi
                 FROM Menu
                 LEFT JOIN Category
                 ON 
                 Menu.CategoryId = Category.Id
                 GROUP BY Menu.CategoryId, Category.CategoryName;"
                 ).ToList();
            var viewModel = new MenuAndCategory()
            {

                Category = categoryList,
                MenuLeftJoin = menuLeftJoin,
                MenuCount = categorySum

            };

            return View(viewModel);
        }

        public IActionResult Editor(int? Id)
        {
            var categoryList = _connection.Query<Category>("SELECT * FROM Category").ToList();
            var menuLeftJoin = _connection.Query<MenuLeftJoinCategory>("SELECT * FROM Menu LEFT JOIN Category ON Menu.CategoryId = Category.Id").ToList();
            var viewModel = new MenuAndCategory()
            {

                Category = categoryList,
                MenuLeftJoin = menuLeftJoin

            };


            ViewBag.Id = Id;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            var addCategory = _connection.Execute
                (
                  @"INSERT INTO Category
                    (CategoryName)
                    VALUES
                    (@CategoryName)", category
                );
            TempData["AddCategory"] = " Category Ekleme Ýþlemi Baþarýyla iþlemi tamamlandý.";
            return RedirectToAction("Editor");
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            var updateCategory = _connection.Execute
             (
               @"UPDATE  Category
               SET
               CategoryName = @CategoryName
               WHERE
               Id=@Id", category
               );
            TempData["UpgradeCategory"] = " Category Güncelleme Ýþlemi Baþarýyla iþlemi tamamlandý.";
            return RedirectToAction("Editor");
        }
        public IActionResult DeleteCategory(int Id)
        {
            var deleteCategory = _connection.Execute("DELETE FROM Category WHERE Id=@Id", new { Id });
            TempData["DeleteCategory"] = "Category successfully deleted.";
            return RedirectToAction("Editor");
        }

        public IActionResult ProductManager(int Id)
        {
            var menuLeftJoin = _connection.Query<MenuLeftJoinCategory>("SELECT * FROM Menu LEFT JOIN Category ON Menu.CategoryId = Category.Id WHERE CategoryId = @CategoryId", new { CategoryId = Id }).ToList();
            var baslikYazisi = _connection.QueryFirst<Category>("SELECT CategoryName From Category Where Id = @Id", new { Id });
            var categoryId = _connection.QueryFirst<Category>("SELECT Id FROM Category WHERE Id = @Id", new { Id });
            ViewBag.CategoryId = categoryId.Id;
            ViewBag.Baslik = baslikYazisi.CategoryName;
            return View(menuLeftJoin);
        }

        [HttpPost]
        public IActionResult AddProductManager(Menu menu)
        {
            var addProduct = _connection.Execute
              (
               @"INSERT INTO Menu
               (CategoryId,FoodName,FoodPrice,FoodImageUrl,FoodDescription)
               VALUES
               (@CategoryId,@FoodName,@FoodPrice,@FoodImageUrl,@FoodDescription)", menu
              );

            TempData["AddProductManager"] = " Ürün Ekleme Ýþlemi Baþarýyla iþlemi tamamlandý.";

            return RedirectToAction("Index");

        }

        public IActionResult DeleteProductManager(int Id)
        {
            var deleteProduct = _connection.Execute("DELETE FROM Menu Where MenuId = @MenuId", new { MenuId = Id });
            TempData["DeleteProductManager"] = " Ürün Silme Ýþlemi Baþarýyla iþlemi tamamlandý.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProductManager(int Id)
        {
            var selectUpdateProduct = _connection.QueryFirstOrDefault<Menu>("SELECT * FROM Menu WHERE MenuId = @Id", new { Id = Id });

            return View(selectUpdateProduct);
        }

        [HttpPost]
        public IActionResult UpdateProductManager(Menu menu)
        {
            var updateProduct = _connection.Execute
             (
                @"UPDATE Menu
                   SET
                  FoodName = @FoodName,FoodPrice = @FoodPrice,FoodImageUrl = @FoodImageUrl
                  WHERE MenuId = @MenuId", menu
             );
            TempData["UpdateProductManager"] = " Ürün Güncelleme Ýþlemi Baþarýyla iþlemi tamamlandý.";
            return RedirectToAction("Index");
        }
    }
}
