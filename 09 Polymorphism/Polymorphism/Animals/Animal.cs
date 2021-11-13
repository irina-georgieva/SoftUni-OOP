﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

        public virtual string ExplainSelf()
        {
            return $"I am {this.name} and my fovourite food is {this.favouriteFood}";
        }

        public Animal(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }
    }
}
