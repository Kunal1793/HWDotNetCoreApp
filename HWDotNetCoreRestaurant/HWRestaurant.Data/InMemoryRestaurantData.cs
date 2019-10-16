using System;
using System.Collections.Generic;
using System.Text;
using HWRestaurant.Core;
using System.Linq;

namespace HWRestaurant.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Dominoes Pizza", Location="Texas", cuisineType=CuisineType.Italian},
                new Restaurant{Id=2, Name="Papa Jones Taco", Location="Seattle", cuisineType=CuisineType.Mexican},
                new Restaurant{Id=3, Name="Sarvanna Bhavan", Location="Phoenix", cuisineType=CuisineType.Indian}


            };
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string Name)
        {
            return from R in restaurants
                   where string.IsNullOrEmpty(Name) || R.Name.StartsWith(Name)
                   orderby R.Name
                   select R;
        }
        public IEnumerable<Restaurant> GetAll()
        {
            // LINQ
            return from R in restaurants orderby R.Name select R;

        }

        public Restaurant GetByID(int Id)
        {
            return restaurants.SingleOrDefault(R => R.Id == Id);
        }

        public Restaurant Update(Restaurant UpdatedRestaurant)
        {
            var Restaurant = restaurants.SingleOrDefault(R => R.Id == UpdatedRestaurant.Id);
            // Gets the specific restuarant to be Updated.
            if (Restaurant != null)
            {
                Restaurant.Name = UpdatedRestaurant.Name;
                Restaurant.Location = UpdatedRestaurant.Location;
                Restaurant.cuisineType = UpdatedRestaurant.cuisineType;
            }
            return Restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public void Insert(Restaurant Addrestaurant)
        {
            restaurants.Add(Addrestaurant);
            Addrestaurant.Id = restaurants.Max(R => R.Id) + 1;
        }

        public Restaurant Delete(int id)
        {
            throw new NotImplementedException();
        }

        Restaurant IRestaurantData.Insert(Restaurant Addrestaurant)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfRestaurants()
        {
            throw new NotImplementedException();
        }
    }
}
