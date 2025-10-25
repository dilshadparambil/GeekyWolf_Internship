using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
    //List of Custom Objects

    public class Book
    {
        //Create a class Book with properties: Title, Author, and Price.
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        public Book(string title, string author, double price)
        {
            Title = title;
            Author = author;
            Price = price;
        }

        public static void Answer()
        {
            Book b1 = new Book("The Hobbit", "J.R.R. Tolkien", 499.50);
            Book b2 = new Book("1984", "George Orwell", 299.99);
            Book b3 = new Book("The Alchemist", "Paulo Coelho", 350.00);

            //Create a List<Book> and add at least 3 books.
            List<Book> books = new List<Book>();
            books.Add(b1);
            books.Add(b2);
            books.Add(b3);

            //Display all book details.
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author} : ₹{book.Price}");
            }

            //Find and display the book with the highest price.
            double highestPrice = 0;
            foreach (var book in books)
            {
                if (highestPrice < book.Price)
                {
                    highestPrice = book.Price;
                }
            }
            foreach (var book in books)
            {
                if (book.Price == highestPrice)
                {
                    Console.WriteLine("\nBook with highest Price");
                    Console.WriteLine($"{book.Title} by {book.Author} : ₹{book.Price}\n");
                }
            }

            //Remove a book by title.
            Console.Write("\nEnter the title of the book to remove: ");
            string removeTitle = Console.ReadLine();
            bool flag = false;

            foreach (var book in books)
            {
                if (book.Title == removeTitle)
                {
                    books.Remove(book);
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                Console.WriteLine("Invalid title, No book removed");
            }
            else
            {
                Console.WriteLine("\nupdated list ");
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} : ₹{book.Price}");
                }
            }


        }

    }

}
