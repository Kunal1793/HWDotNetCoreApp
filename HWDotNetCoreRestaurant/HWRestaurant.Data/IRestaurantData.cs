using HWRestaurant.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWRestaurant.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantByName(string Name);
        Restaurant GetByID(int Id);

        Restaurant Update(Restaurant UpdatedRestaurant);

        Restaurant Delete(int id);
        Restaurant Insert(Restaurant Addrestaurant);
        int GetCountOfRestaurants();
        int Commit();

    }
}
