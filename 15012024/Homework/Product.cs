using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    internal class Product
    {
        public string Name;
        public decimal Price;

        public virtual void ShowInfo()
        {
            Console.WriteLine("Name: "+Name);
            Console.WriteLine("Price: " + Price);
        }
    }
}
