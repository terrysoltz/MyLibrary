using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyLibrary.Models
{
    public class LibraryInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var publishers = new List<Publisher>
            {
                new Publisher{Name = "Penguin", Address = "375 Hudson St New York NY", Phone = "212 - 366 - 2000"},
                new Publisher{Name = "Harcourt", Address = "125 High St Boston MA", Phone = "617 - 351 - 5000"},
                new Publisher{Name = "Viking", Address = "375 Hudson St New York NY", Phone = "212 - 366 - 2000"},
                new Publisher{Name = "Doubleday", Address = "1745 Broadway New York NY", Phone = "212 - 940 - 7390"},
                new Publisher{Name = "Putnam", Address = "375 Hudson St New York NY", Phone = "212 - 366 - 2000"},
                new Publisher{Name = "Harper", Address = "53 Glenmaura National Blvd #300 Moosic P", Phone = "570-941-1500"},
                new Publisher{Name = "Schocken", Address = "1745 Broadway New York NY", Phone = "212-940-7390"},
                new Publisher{Name = "Navillus", Address = "1958 Onyx St Eugene OR", Phone = "541 - 683 - 6837"}
            };

            publishers.ForEach(s => context.Publishers.Add(s));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book{BookID = 1, Title="The Lost Tribe", PublisherName="Penguin" },
                new Book{BookID = 2, Title="Eden", PublisherName="Harcourt" },
                new Book{BookID = 3, Title="Memoirs Found in a Bathtub", PublisherName="Harcourt" },
                new Book{BookID = 4, Title="Chain of Chance", PublisherName="Harcourt" },
                new Book{BookID = 5, Title="It", PublisherName="Viking" },
                new Book{BookID = 6, Title="Misery", PublisherName="Viking" },
                new Book{BookID = 7, Title="Carrie", PublisherName="Doubleday" },
                new Book{BookID = 8, Title="Ubik", PublisherName="Doubleday" },
                new Book{BookID = 9, Title="Now Wait for Last Year", PublisherName="Doubleday" },
                new Book{BookID = 10, Title="The Man in the High Castle", PublisherName="Putnam" },
                new Book{BookID = 11, Title="Kafka on the Shore", PublisherName="Doubleday" },
                new Book{BookID = 12, Title="A Wild Sheep Chase", PublisherName="Doubleday" },
                new Book{BookID = 13, Title="Skinwalkers", PublisherName="Harper" },
                new Book{BookID = 14, Title="Coyote Waits", PublisherName="Harper" },
                new Book{BookID = 15, Title="Chronic City", PublisherName="Doubleday" },
                new Book{BookID = 16, Title="The Fortress of Solitude", PublisherName="Doubleday" },
                new Book{BookID = 17, Title="Nausea", PublisherName="Penguin" },
                new Book{BookID = 18, Title="The Wall", PublisherName="Penguin" },
                new Book{BookID = 19, Title="The Complete Stories of Kafka", PublisherName="Schocken" },
                new Book{BookID = 20, Title="100 Hikes in Northwest Oregon", PublisherName="Navillus" },
                new Book{BookID = 21, Title="100 Hikes in Central Oregon", PublisherName="Navillus" }
            };

            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();

            var bookauthors = new List<BookAuthor>
            {
                new BookAuthor{BookAuthorID = 1, BookID = 1, Name = "Some Guy"},
                new BookAuthor{BookAuthorID = 2, BookID = 2, Name = "Stanislaw Lem"},
                new BookAuthor{BookAuthorID = 3, BookID = 3, Name = "Stanislaw Lem"},
                new BookAuthor{BookAuthorID = 4, BookID = 4, Name = "Stanislaw Lem"},
                new BookAuthor{BookAuthorID = 5, BookID = 5, Name = "Stephen King"},
                new BookAuthor{BookAuthorID = 6, BookID = 6, Name = "Stephen King"},
                new BookAuthor{BookAuthorID = 7, BookID = 7, Name = "Stephen King"},
                new BookAuthor{BookAuthorID = 8, BookID = 8, Name = "Phillip K Dick"},
                new BookAuthor{BookAuthorID = 9, BookID = 9, Name = "Phillip K Dick"},
                new BookAuthor{BookAuthorID = 10, BookID = 10, Name = "Phillip K Dick"},
                new BookAuthor{BookAuthorID = 11, BookID = 11, Name = "Haruki Murakami"},
                new BookAuthor{BookAuthorID = 12, BookID = 12, Name = "Haruki Murakami"},
                new BookAuthor{BookAuthorID = 13, BookID = 13, Name = "Tony Hillerman"},
                new BookAuthor{BookAuthorID = 14, BookID = 14, Name = "Tony Hillerman"},
                new BookAuthor{BookAuthorID = 15, BookID = 15, Name = "Jonathan Lethem"},
                new BookAuthor{BookAuthorID = 16, BookID = 16, Name = "Jonathan Lethem"},
                new BookAuthor{BookAuthorID = 17, BookID = 17, Name = "Jean Paul Sartre"},
                new BookAuthor{BookAuthorID = 18, BookID = 18, Name = "Jean Paul Sartre"},
                new BookAuthor{BookAuthorID = 19, BookID = 19, Name = "Franz Kafka"},
                new BookAuthor{BookAuthorID = 20, BookID = 20, Name = "William L Sullivan"},
                new BookAuthor{BookAuthorID = 21, BookID = 21, Name = "William L Sullivan"}
            };

            bookauthors.ForEach(s => context.BookAuthors.Add(s));
            context.SaveChanges();

            var branches = new List<Branch>
            {
                new Branch{BranchID = 1, BranchName = "Central", Address = "123 Main St Anytown OR"},
                new Branch{BranchID = 2, BranchName = "Sharpstown", Address = "8 Sharp's Circle Anytown OR"},
                new Branch{BranchID = 3, BranchName = "Southside", Address = "1745 South Park Blvd Anytown OR"},
                new Branch{BranchID = 4, BranchName = "Uptown", Address = "100 Broadway Anytown OR"}
            };

            branches.ForEach(s => context.Branches.Add(s));
            context.SaveChanges();

            var copies = new List<Copies>
            {
                new Copies{CopiesID = 1, BookID = 1, BranchID = 1, NoCopies = 3},
                new Copies{CopiesID = 2, BookID = 1, BranchID = 2, NoCopies = 2},
                new Copies{CopiesID = 3, BookID = 2, BranchID = 1, NoCopies = 3},
                new Copies{CopiesID = 4, BookID = 2, BranchID = 3, NoCopies = 2},
                new Copies{CopiesID = 5, BookID = 2, BranchID = 4, NoCopies = 2},
                new Copies{CopiesID = 6, BookID = 3, BranchID = 1, NoCopies = 4},
                new Copies{CopiesID = 7, BookID = 4, BranchID = 2, NoCopies = 3},
                new Copies{CopiesID = 8, BookID = 4, BranchID = 3, NoCopies = 3},
                new Copies{CopiesID = 9, BookID = 5, BranchID = 1, NoCopies = 5},
                new Copies{CopiesID = 10, BookID = 5, BranchID = 4, NoCopies = 4},
                new Copies{CopiesID = 11, BookID = 6, BranchID = 1, NoCopies = 3},
                new Copies{CopiesID = 12, BookID = 6, BranchID = 3, NoCopies = 3},
                new Copies{CopiesID = 13, BookID = 6, BranchID = 4, NoCopies = 3},
                new Copies{CopiesID = 14, BookID = 7, BranchID = 1, NoCopies = 4},
                new Copies{CopiesID = 15, BookID = 8, BranchID = 1, NoCopies = 3},
                new Copies{CopiesID = 16, BookID = 8, BranchID = 3, NoCopies = 2},
                new Copies{CopiesID = 17, BookID = 9, BranchID = 1, NoCopies = 3},
                new Copies{CopiesID = 18, BookID = 10, BranchID = 1, NoCopies = 4},
                new Copies{CopiesID = 19, BookID = 10, BranchID = 2, NoCopies = 3},
                new Copies{CopiesID = 20, BookID = 10, BranchID = 3, NoCopies = 3},
                new Copies{CopiesID = 21, BookID = 10, BranchID = 4, NoCopies = 2},
                new Copies{CopiesID = 22, BookID = 11, BranchID = 2, NoCopies = 2},
                new Copies{CopiesID = 23, BookID = 11, BranchID = 3, NoCopies = 3},
                new Copies{CopiesID = 24, BookID = 12, BranchID = 2, NoCopies = 2},
                new Copies{CopiesID = 25, BookID = 12, BranchID = 3, NoCopies = 3},
                new Copies{CopiesID = 26, BookID = 13, BranchID = 1, NoCopies = 3},
                new Copies{CopiesID = 27, BookID = 13, BranchID = 2, NoCopies = 3},
                new Copies{CopiesID = 28, BookID = 13, BranchID = 4, NoCopies = 2},
                new Copies{CopiesID = 29, BookID = 14, BranchID = 2, NoCopies = 2},
                new Copies{CopiesID = 30, BookID = 14, BranchID = 3, NoCopies = 3},
                new Copies{CopiesID = 31, BookID = 14, BranchID = 4, NoCopies = 2},
                new Copies{CopiesID = 32, BookID = 15, BranchID = 1, NoCopies = 3},
                new Copies{CopiesID = 33, BookID = 16, BranchID = 1, NoCopies = 3},
                new Copies{CopiesID = 34, BookID = 17, BranchID = 1, NoCopies = 3},
                new Copies{CopiesID = 35, BookID = 17, BranchID = 2, NoCopies = 2},
                new Copies{CopiesID = 36, BookID = 17, BranchID = 4, NoCopies = 2},
                new Copies{CopiesID = 37, BookID = 18, BranchID = 1, NoCopies = 2},
                new Copies{CopiesID = 38, BookID = 18, BranchID = 4, NoCopies = 3},
                new Copies{CopiesID = 39, BookID = 19, BranchID = 1, NoCopies = 4},
                new Copies{CopiesID = 40, BookID = 19, BranchID = 3, NoCopies = 4},
                new Copies{CopiesID = 41, BookID = 20, BranchID = 1, NoCopies = 5},
                new Copies{CopiesID = 42, BookID = 20, BranchID = 2, NoCopies = 4},
                new Copies{CopiesID = 43, BookID = 20, BranchID = 3, NoCopies = 4},
                new Copies{CopiesID = 44, BookID = 20, BranchID = 4, NoCopies = 2},
                new Copies{CopiesID = 45, BookID = 21, BranchID = 1, NoCopies = 5},
                new Copies{CopiesID = 46, BookID = 21, BranchID = 2, NoCopies = 4},
                new Copies{CopiesID = 47, BookID = 21, BranchID = 4, NoCopies = 2}
            };

            copies.ForEach(s => context.Copies.Add(s));
            context.SaveChanges();

        }
    }
}