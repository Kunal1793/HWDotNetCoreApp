using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HWRestaurant.Core;
using HWRestaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HWRestaurant.WEB.Pages.MyRestaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant restaurant { get; set; }

        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData restaurantData) 
        {
            this.restaurantData = restaurantData;

        }
        public ActionResult OnGet(int RestaurantId) 
        // Getting the Restaurant ID from the Route
        {
            restaurant = restaurantData.GetByID(RestaurantId);
            if (restaurant == null) 
            {
                return RedirectToAction("./NotFound", RestaurantId);
            }
            return Page();

        }
    }
}