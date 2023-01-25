using Microsoft.EntityFrameworkCore; // necessary for connecting to from API service
using rsntdb.Models;

using rsntdb.LocalStorage;

namespace rsntdb.Data
{
    public class ContextFiling : DbContext, IContext
    {
        public List<Food> Foods { get; set; }
        public List<FoodDTO> FoodsDTO { get; set; }
        public List<Cuisine> Cuisines { get; set; }
        public List<City> Cities { get; set; }

        public ContextFiling(DbContextOptions<ContextFiling> options)
        {
        }

        private void LoadFood()
        {
            LoadCuisine();
            try
            {
                Foods = Foods.LoadFromMemory();
                FoodToDTO();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void LoadCuisine()
        {
            try
            {
                Cuisines = Cuisines.LoadFromMemory();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        private void LoadCity()
        {
            try
            {
                Cities = Cities.LoadFromMemory();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
                /*
                Cities = new List<City>();
                Cities.Add(new City(0, "Yorktown"));
                Cities.SaveToMemory();
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void FoodToDTO()
        {
            FoodsDTO = new List<FoodDTO>((from Food F in Foods
                                          join Cuisine C in Cuisines
                                          on F.cuisineid equals C.id
                                          select new FoodDTO(F.name, C.name)));
        }

        public async Task<IEnumerable<FoodDTO>> GetAllFood()
        {
            LoadFood();
            return await Task.Run(() => (IEnumerable<FoodDTO>)this.FoodsDTO);
        }

        public async Task<IEnumerable<string>> GetFoodByCuisine(string cuisine)
        {
            LoadFood();
            return await Task.Run(() => (IEnumerable<string>)(from FoodDTO F in FoodsDTO where F.cuisine == cuisine select F.food));
        }

        public async Task<FoodDTO> GetFoodByName(string name)
        {
            LoadFood();
            Food food = this.Foods.Find(f => f.name == name);
            Cuisine cuis = this.Cuisines.Find(c => c.id == food.cuisineid);
            return await Task.Run(() => new FoodDTO(food.name, cuis.name));
        }

        public async Task<bool> AddNewFood(FoodDTO food)
        {
            LoadFood();
            bool foodExists = Foods.Any(f => f.name == food.food);
            Cuisine c = Cuisines.Find(c => c.name == food.cuisine);

            if (foodExists || c==null) return false;
            else
            {
                Foods.Add(new(
                    (from Food f in Foods select f.id).Max()+1,
                    food.food,
                    c.id));
                Foods.SaveToMemory();
                return true;
            }
        }

        public async Task<IEnumerable<string>> GetCuisines()
        {
            LoadCuisine();
            return await Task.Run(() => (from Cuisine C in Cuisines select C.name));
        }

        public async Task<bool> AddNewCuisine(string cuisine)
        {
            LoadCuisine();
            bool cuisineExists = Cuisines.Any(c => c.name == cuisine);

            if (cuisineExists) return false;
            else
            {
                Cuisines.Add(new(
                    (from Cuisine c in Cuisines select c.id).Max()+1,
                    cuisine));
                Cuisines.SaveToMemory();
                return true;
            }
        }

        public async Task<IEnumerable<string>> GetCities()
        {
            LoadCity();
            return await Task.Run(() => (from City C in Cities select C.name));
        }

        public async Task<bool> AddNewCity(string city)
        {
            LoadCity();
            bool cityExists = Cities.Any(c => c.name == city);

            if (cityExists) return false;
            else
            {
                Cities.Add(new(
                    (from City c in Cities select c.id).Max() + 1,
                    city));
                Cities.SaveToMemory();
                return true;
            }
        }
    }
}