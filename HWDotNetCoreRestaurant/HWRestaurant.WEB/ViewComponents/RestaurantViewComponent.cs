using HWRestaurant.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HWRestaurant.WEB.ViewComponents
{
    public class RestaurantViewComponent: ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke() 
        {
            var count = restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
