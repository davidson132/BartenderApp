using BartenderApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BartenderApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Cart> CartList = _db.CartItems;
            return View(CartList);
        }

        public IActionResult AddToCart(int? Id) {
            Bartender drink = _db.Bartender.Find(Id);
            Cart item = new Cart();
            item.Drink = drink;
            item.Quantity = 1;
            item.Total = item.Drink.Price * item.Quantity;

            //Error with this check variable. Find different solution to check if the drink already exists in CartItems table
            //var check = _db.CartItems.Find(item.Drink.DrinkName);


            //sql query not working either, try to figure this out
            /*
            var find = select * 
                       from _db.CartItems
                       where _db.Bartender.DrinkName = _db.CartItems.Drink.DrinkName;
            
            if (check == null)
            {
                _db.CartItems.Add(item);
                _db.SaveChanges();
                return View();
            }
            else 
            {
                item.Quantity++;
                _db.CartItems.Update(item);
                _db.SaveChanges();
                return View();
            }
        */
            return View();
        
        
        }

    }
}
