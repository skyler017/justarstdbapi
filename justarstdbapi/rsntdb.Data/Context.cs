using Microsoft.EntityFrameworkCore;
using rsntdb.Models;

namespace rsntdb.Data
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }


        public DbSet<Food> Foods { get; set; } = null!;

        //////
        public Task CommitChangesAsync()
        {
            return SaveChangesAsync();
        }

        public void DenoteFoodModified(Food food)
        {
            Entry(food).State = EntityState.Modified;
        }

        public async Task<Food> GetFoodById(int id)
        {
            return await Foods.FindAsync(id);
        }

        public async Task<IEnumerable<Food>> GetAllFood()
        {
            return await Foods.ToListAsync<Food>();
        }
    }
}