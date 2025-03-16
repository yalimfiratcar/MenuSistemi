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

       

    }
}
