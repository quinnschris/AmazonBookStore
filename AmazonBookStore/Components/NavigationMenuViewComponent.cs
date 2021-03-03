using System;
using AmazonBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace AmazonBookStore.Components
{

    //Used to create a "view component that can be dropped into the _Layout.cshtml to create a catergory menu

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
