using FishTank.Core.Abstract;
using FishTank.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FishTank.Core
{
    public class Tank : ITank
    {
        public Tank()
        {
            FishList = new List<Fish>();
        }

        public bool AddFish(Fish fish)
        {
            if (fish == null)
                return false;

            FishList.Add(fish);
            return true;
        }

        public decimal Feed() => FishList.Sum(f => f.FoodRequired);

        public List<Fish> GetFishList() => FishList;

        public List<Fish> FishList;

    }
}
