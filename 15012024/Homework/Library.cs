using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    internal class Library
    {
        public Book[] Books=new Book[0];
        public void AddBook(Book book)
        {
            Array.Resize(ref Books,Books.Length+1);
            Books[Books.Length-1] = book;
        }

        public Book FindBookByName(string name)
        {
            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i].Name == name) return Books[i];
            }
            return null;
        }

        public int FindBookIndexByName(string name)
        {
            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i].Name == name) return i;
            }

            return -1;
        }

        public bool RemoveBookByName(string name)
        {
            int wantedIndex = FindBookIndexByName(name);

            if (wantedIndex == -1) return false;

            for (int i = wantedIndex; i < Books.Length-1; i++)
            {
                var temp = Books[i];
                Books[i] = Books[i+1];
                Books[i+1] = temp;
            }

            Array.Resize(ref Books, Books.Length - 1);
            return true;
        }
    }
}
