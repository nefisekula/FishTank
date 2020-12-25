using FishTank.Core.Entities;
using FishTank.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace FishTank.UI
{
    public class App
    {
        private readonly IConfiguration _config;
        private readonly ITank _tank;
        private readonly ITankSaver _xmlSaver;

        public App(IConfiguration config, ITank tank, ITankSaver xmlSaver)
        {
            _config = config;
            _tank = tank;
            _xmlSaver = xmlSaver;
        }

        public void Run()
        {
            //tank null kontrol
            if (_tank != null)
            {
                var goldFish = new GoldFish("Gold");
                _tank.AddFish(goldFish);

                var angelFish = new AngelFish("Angel");
                _tank.AddFish(angelFish);


                var babelFish = new BabelFish("Babel");
                _tank.AddFish(babelFish);

                var goldFishNemo = new GoldFish("Nemo");
                _tank.AddFish(goldFishNemo);

                var tankFile = _xmlSaver.Save();

                if(!string.IsNullOrEmpty(tankFile))
                    Console.WriteLine(tankFile + Environment.NewLine);

                foreach (var item in _tank.GetFishList())
                {
                    Console.WriteLine($"Fishes in the Tank: {item.Name}");
                }

            }
            else
            {
                Console.WriteLine("Tank is not found!");
            }

            
        }
    }
}
