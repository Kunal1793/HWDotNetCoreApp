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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData irestaurantData;

        [BindProperty(SupportsGet = true)]
        public Restaurant restaurant { get; set; }

        public DeleteModel(IRestaurantData irestaurantData)
        {
            this.irestaurantData = irestaurantData;
        }
        public void OnGet(int RestaurantId)
        {
            restaurant = irestaurantData.GetByID(RestaurantId); 
            // 1-With the ID passed from the route, get the single Restaurant to be deleted.
            // 2-Show the Single Restaurant
        }
        // If the user confirms delete, pass the the Restaurant Id to OnPost method.
        public IActionResult OnPost(int RestaurantId) 
        {
            irestaurantData.Delete(RestaurantId);
            irestaurantData.Commit();
            TempData["DeleteMessage"] = "Deleted Succesfully!";
            return RedirectToPage("./List1");
        }
    }
}