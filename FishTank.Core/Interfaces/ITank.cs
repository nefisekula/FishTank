using FishTank.Core.Abstract;
using System.Collections.Generic;

namespace FishTank.Core.Interfaces
{
    public interface ITank
    {
        bool AddFish(Fish fish);

        decimal Feed();

        List<Fish> GetFishList();
    }
}
