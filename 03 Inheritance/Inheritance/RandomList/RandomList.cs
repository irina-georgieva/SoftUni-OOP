using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomRandomList
{
    public class RandomList: List<string>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }
        
        public string RandomString()
        {
            int index = random.Next(0, Count);

            var element = this[index];
            RemoveAt(index);
            return element;
        }
    }

}
