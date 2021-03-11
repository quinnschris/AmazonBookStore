using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AmazonBookStore.Infrastructure;
namespace AmazonBookStore.Models
{
    public class SessionCart : Cart
    {
        // This model is used to maintain items that are stored in a cart during a session by
        // converting to json and storing in the session variable

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(BookInfo info, int quantity)
        {
            base.AddItem(info, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(BookInfo info)
        {
            base.RemoveLine(info);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
