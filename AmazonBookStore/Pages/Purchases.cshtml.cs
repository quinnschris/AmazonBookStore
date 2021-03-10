using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonBookStore.Infrastructure;
using AmazonBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AmazonBookStore.Pages
{
    public class PurchasesModel : PageModel
    {
        private IBookstoreRepository repository;

        // Constructor

        public PurchasesModel (IBookstoreRepository repo)
        {
            repository = repo;
        }


        // Properties

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }


        //Methods

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            BookInfo bookInfo = repository.BookInfos.FirstOrDefault(b => b.Id == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(bookInfo, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
