using FishTank.Core.Enums;
using System;

namespace FishTank.Core.Abstract
{
    public abstract class Fish
    {
        protected Fish(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("The Name cannot be null.");

            Name = name;
        }

        public string Name { get; set; }

        public abstract FishType FishType { get; }

        public abstract decimal FoodRequired { get; }


    }
}
