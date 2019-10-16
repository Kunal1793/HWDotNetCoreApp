using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HWRestaurant.Core;
using HWRestaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HWRestaurant.WEB.Pages.MyRestaurants
{
    public class List1Model : PageModel
    {
        private readonly IRestaurantData restaurantData;

        private readonly ILogger<List1Model> logger;

        [BindProperty(SupportsGet = true)] // Like 2 way Binding or NgModel in Angular.
        public string SearchTerm { get; set; } // Like 2 way Binding or NgModel in Angular.
        [TempData]
        public string Message { get; set; }
        [TempData]
        public string DeleteMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }


        public List1Model(IRestaurantData restaurantData, ILogger<List1Model> logger)
        {
            this.restaurantData = restaurantData;
            // this--> it means I am reffering to the variable that has been defined in this context.
            this.logger = logger;        
        }
        public void OnGet()
        {
            //Restaurants = restaurantData.GetAll().ToList();
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
            logger.LogError("Some thing Went Wrong!");
            logger.LogInformation("Restaurants List!");
            logger.LogWarning("Get More Restaurants");




        }
    }
}