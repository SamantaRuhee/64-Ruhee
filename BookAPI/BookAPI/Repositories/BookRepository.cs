using System;
using BookAPI.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BookAPI.Repositories
{
        public class BookRepository
        {
            public Book Read(Guid id)
            {
                var allBooks = LoadData();
                return allBooks.Find(c => c.Id == id);
            }

            public List<Book> ReadAll()
            {
                var allBooks = LoadData();
                return allBooks;
            }

            public void Create(Book book)
            {
                var allBooks = LoadData();
                book.Id = Guid.NewGuid();
                allBooks.Add(book);
                SaveData(allBooks);
            }

            public void Update(Book book)
            {
                var allBooks = LoadData();
                var savedCourse = allBooks.Find(c => c.Id == book.Id);
                savedCourse.bookName = book.bookName;
                savedCourse.bookAuthor = book.bookAuthor;
                savedCourse.publishDate = book.publishDate;
                SaveData(allBooks);
            }

            public void Delete(Guid id)
            {
                var allBooks = LoadData();
                var bookToRemove = allBooks.Find(c => c.Id == id);
                allBooks.Remove(bookToRemove);
                SaveData(allBooks);
            }

            private List<Book> LoadData()
            {
                var dataString = File.ReadAllText("J:/Educational stuffs/5th semester/ServerProgramming/67-bookapi/BookAPI/BookAPI/Data/Books.json");
                return JsonConvert.DeserializeObject<List<Book>>(dataString);
            }

            private void SaveData(List<Book> data)
            {
                var dataString = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText("J:/Educational stuffs/5th semester/ServerProgramming/67-bookapi/BookAPI/BookAPI/Data/Books.json", dataString);
            }
        }
    }
