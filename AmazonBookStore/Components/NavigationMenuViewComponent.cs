using System;
using AmazonBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace AmazonBookStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookstoreRepository repository;

        public NavigationMenuViewComponent (IBookstoreRepository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedCategory = RouteData?.Values["Category"];

            return View(repository.BookInfos
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
