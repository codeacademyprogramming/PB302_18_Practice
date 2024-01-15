using System;
using System.Text;

namespace Homework
{
    internal class Program
    {
        static void SetHikmet(string name)
        {
            name = "Hikmet";
        }

        static void Main(string[] args)
        {
            int n = 34;
            Library library = new Library();

            string opt;
            do
            {
                ShowMenu();
                Console.WriteLine("Select operation");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        var addResult = Add(library);
                        if (addResult) Console.WriteLine("Book successfully added");
                        else Console.WriteLine("Book exist!");
                        break;
                    case "2":
                        var removeResult = Remove(library);
                        if (removeResult) Console.WriteLine("Book successfully removed");
                        else Console.WriteLine("Book not found!");
                        break;
                    case "3":

                        break;
                    case "4":
                        for (int i = 0; i < library.Books.Length; i++)
                        {
                            library.Books[i].ShowInfo();
                        }
                        break;
                    case "5":
                        Search(library);
                        break;
                    case "0":
                        Console.WriteLine("Finished");
                        break;
                    default:
                        Console.WriteLine("Wrong choise");
                        break;
                }

            } while (opt!="0");
        }

        static void ShowMenu()
        {
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Remove");
            Console.WriteLine("3. Find ");
            Console.WriteLine("4. Show all");
            Console.WriteLine("5. Search");
            Console.WriteLine("0. Exit");
        }

        static bool Add(Library library)
        {
            string name;
            do
            {
                Console.WriteLine("Name:");
                name = Console.ReadLine();
                name = FixNameFormat(name);

            } while (!CheckName(name));

            if (library.FindBookByName(name) != null) return false;

            string priceStr;
            decimal price;
            do
            {
                Console.WriteLine("Price:");
                priceStr = Console.ReadLine();

            } while (!decimal.TryParse(priceStr,out price) || price<0);
          

            Console.WriteLine("Genre:");
            string genre = Console.ReadLine();

            Book newBook = new Book(FixNameFormat(name), genre, price);
            library.AddBook(newBook);

            return true;
        }

        static bool Remove(Library library)
        {
            Console.WriteLine("Book name: ");
            string name = Console.ReadLine();

            return library.RemoveBookByName(name);
        }

        static bool HasOnlyLetter(string str)
        {
            if (String.IsNullOrWhiteSpace(str)) return false;

            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i])) return false;
            }

            return true;
        }
        //  ali     and   nino->ali and nino ali andnino
        static string FixNameFormat(string str)
        {
            str = str.Trim();
            string[] words = str.Split(' ');

            StringBuilder nameBuilder = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "")
                {
                    nameBuilder.Append(words[i]+" ");
                }
            }

            return nameBuilder.ToString().TrimEnd();
        }

        static bool CheckName(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) return false;

            if (name.Length < 3 || name.Length > 20) return false;

            var words = name.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (!HasOnlyLetter(words[i])) return false;
            }

            return true;    
        }

        static void Search(Library library)
        {
            Console.WriteLine("Search ");
            string search = Console.ReadLine();

            for (int i = 0; i < library.Books.Length; i++)
            {
                if (library.Books[i].Name.Contains(search)) library.Books[i].ShowInfo();
            }
        }
    }
}
