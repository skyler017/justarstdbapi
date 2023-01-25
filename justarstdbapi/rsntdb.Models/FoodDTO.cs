using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsntdb.Models
{
    public class FoodDTO
    {
        public string food { get; set; }
        public string cuisine { get;set; }

        public FoodDTO() { }
        public FoodDTO(string food, string cuisine)
        {
            this.food = food;
            this.cuisine = cuisine;
        }
    }
}
