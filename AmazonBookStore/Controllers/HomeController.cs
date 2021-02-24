using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AmazonBookStore.Models;
using AmazonBookStore.Models.ViewModels;

namespace AmazonBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBookstoreRepository _repository;

        //variable for items per page
        public int PageSize = 5;

        //This was some of the stuff we changed. All I really know is we are passing
        //the data into the view by accessing the repository stored in the database.

        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(int page = 1)
        {
            return View(new BookInfoViewModel
            {
                BookInfos = _repository.BookInfos
                            .OrderBy(p => p.Id)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize)
                        ,
                      PageInfo = new PageInfo
                      {
                          CurrentPage = page,
                          ItemsPerPage = PageSize,
                          TotalNumItems = _repository.BookInfos.Count()
                      }
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
