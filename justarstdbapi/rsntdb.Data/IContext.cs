using Microsoft.EntityFrameworkCore;
using rsntdb.Models;

namespace rsntdb.Data
{
    public interface IContext
    {
        public DbSet<Food> Foods { get; set; }
        public Task CommitChangesAsync();
        public void DenoteFoodModified(Food food);
        public Task<Food> GetFoodById(int id);

    }
}
