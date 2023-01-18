using Microsoft.EntityFrameworkCore;
using rsntdb.Models;

namespace rsntdb.Data
{
    public interface IContext
    {
        public Task CommitChangesAsync();
        public DbSet<Food> Foods { get; set; }
        public void DenoteFoodModified(Food food);
        public Task<Food> GetFoodById(int id);
        public Task<IEnumerable<Food>> GetAllFood();

    }
}
