using FishTank.Core.Abstract;
using FishTank.Core.Enums;

namespace FishTank.Core.Entities
{
    public class BabelFish : Fish
    {
        public BabelFish(string name) : base(name) { }

        public override FishType FishType => FishType.BabelFish;
        public override decimal FoodRequired => 0.3m;
    }
}
