using FishTank.Core.Abstract;
using FishTank.Core.Enums;

namespace FishTank.Core.Entities
{
    public class AngelFish : Fish
    {
        public AngelFish(string name) : base(name) { }

        public override FishType FishType => FishType.AngelFish;
        public override decimal FoodRequired => 0.2m;
    }
}
