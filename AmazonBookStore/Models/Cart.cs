using System;
using System.Collections.Generic;
using System.Linq;
namespace AmazonBookStore.Models
{
    public class Cart
    {
        // Store each piece of information together

        public List<CartLine> Lines { get; set; } = new List<CartLine>();


        public virtual void AddItem (BookInfo info, int qty)
        {
            CartLine line = Lines.Where(b => b.BookInfo.Id == info.Id).FirstOrDefault();

            // Checks if anything is currently stored in the cart

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    BookInfo = info,
                    Quanity = qty
                });
            }
            else
            {
                line.Quanity += qty;
            }
        }

        // Used to remove a single item from cart
        public virtual void RemoveLine(BookInfo info) =>
            Lines.RemoveAll(x => x.BookInfo.Id == info.Id);


        // Used to clear cart
        public virtual void Clear() => Lines.Clear();


        // Used to calculate sum of cart
        public float TotalSum()
        {
            return Lines.Sum(e => e.BookInfo.Price * e.Quanity);
        }


        // Class for object CartLine
        public class CartLine
        {
            public int CartLineID { get; set; }
            public BookInfo BookInfo { get; set; }
            public int Quanity { get; set; }
        }
    }
}
