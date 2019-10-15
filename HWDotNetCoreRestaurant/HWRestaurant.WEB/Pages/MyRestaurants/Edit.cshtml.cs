using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HWRestaurant.Core;
using HWRestaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HWRestaurant.WEB.Pages.MyRestaurants
{
    public class EditModel : PageModel
    {

        private readonly IRestaurantData restaurantData;
        [BindProperty(SupportsGet = true)]
        public Restaurant restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        private readonly IHtmlHelper htmlHelper;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper) 
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? RestaurantId) 
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (RestaurantId.HasValue)
            {
                restaurant = restaurantData.GetByID(RestaurantId.Value);
            }
            else 
            {
                restaurant = new Restaurant();
            }
            if (restaurant == null) 
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }

        public IActionResult onPost() 
        {
            if (!ModelState.IsValid) 
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (restaurant.Id > 0)
            {
                restaurantData.Update(restaurant);
            }
            else
            {
                restaurantData.Insert(restaurant);
            }
            restaurantData.Commit();
            TempData["Message"] = "Restaurant Saved!";
            return RedirectToPage("./Detail", new { RestaurantId = restaurant.Id});

        }



    }
}