using Microsoft.EntityFrameworkCore;
using rsntdb.Models;

namespace rsntdb.Data
{
    public interface IContext
    {
        //public Task CommitChangesAsync();
        //public DbSet<Food> Foods { get; set; }
        //public void DenoteFoodModified(Food food);
        public Task<IEnumerable<FoodDTO>> GetAllFood();
        public Task<IEnumerable<string>> GetFoodByCuisine(string cuisine);
        public Task<FoodDTO> GetFoodByName(string name);
        public Task<bool> AddNewFood(FoodDTO food);
        public Task<IEnumerable<string>> GetCuisines();
        public Task<bool> AddNewCuisine(string cuisine);
        public Task<IEnumerable<string>> GetCities();
        public Task<bool> AddNewCity(string city);
    }
}
