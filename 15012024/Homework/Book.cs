using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    internal class Book:Product
    {
        public Book()
        {

        }

        public Book(string name,string genre,decimal price)
        {
            Name= name;
            Genre= genre;
            Price= price;
        }
        public string Genre;

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Genre: "+Genre);
        }
    }
}
