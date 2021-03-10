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

        public PurchasesModel (IBookstoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }


        // Properties

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }


        //Methods

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long Id, string returnUrl)
        {
            BookInfo bookInfo = repository.BookInfos.FirstOrDefault(b => b.Id == Id);

            Cart.AddItem(bookInfo, 1);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long id, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.BookInfo.Id == id).BookInfo);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
