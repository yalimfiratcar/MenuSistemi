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

    }
}
