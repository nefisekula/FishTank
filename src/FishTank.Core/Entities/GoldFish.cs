using FishTank.Core.Abstract;
using FishTank.Core.Enums;

namespace FishTank.Core.Entities
{
    public class GoldFish : Fish
    {
        public GoldFish(string name) : base(name) { }

        public override FishType FishType => FishType.GoldFish;
        public override decimal FoodRequired => 0.1m;
    }
}
