using System;
using System.Collections.Generic;
using System.Text;
using HWRestaurant.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HWRestaurant.Data
{
    public class SQLRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext db;

        // RestaurantDbContext --> Is like a Database.

        public SQLRestaurantData(RestaurantDbContext db)
        {
            this.db = db;


        }
        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var DeleteRestaurant = GetByID(id);
            if (DeleteRestaurant != null) 
            {
                db.restaurants.Remove(DeleteRestaurant);
            }
            return DeleteRestaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetByID(int Id)
        {
            return db.restaurants.Find(Id);
        }

        public int GetCountOfRestaurants()
        {
            return db.restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string Name)
        {

            var Query =  from R in db.restaurants
                   where string.IsNullOrEmpty(Name) 
                   || R.Name.StartsWith(Name)
                   orderby R.Name
                   select R;
            return Query;
        }

        public Restaurant Insert(Restaurant Addrestaurant)
        {
            db.Add(Addrestaurant);
            return Addrestaurant;
        }

        public Restaurant Update(Restaurant UpdatedRestaurant)
        {
            var entity = db.restaurants.Attach(UpdatedRestaurant);
            entity.State = EntityState.Modified;
            return UpdatedRestaurant;
        }
    }
}
