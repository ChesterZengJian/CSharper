using MongoDbDemo.Models;
using MongoDbDemo.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbDemo.Services
{
    public class BookService
    {
        private readonly BookRepository m_bookRepository;
        private readonly BaseRepository<Author> m_authorRepository;

        public BookService()
        {
            m_bookRepository = new BookRepository(Constants.BookCollection);
            m_authorRepository = new BaseRepository<Author>(Constants.AuthorCollection);
        }

        public async Task InsertBook()
        {
            var author = new Author
            {
                FirstName = "Chester",
                LastName = "Z",
                BirthDate = DateTime.UtcNow.ToString("s"),
                ScientificDegree = "High School"
            };
            await m_authorRepository.InsertOneAsync(author);

            var book = new Book
            {
                AuthorId = author.Id,
                Title = "MongoDb Book",
                Content = "Good book",
                DownloadCount = 1100,
                IsVerified = true,
                PublishYear = DateTime.UtcNow.Year
            };
            await m_bookRepository.InsertOneAsync(book);
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await m_bookRepository.GetAllAsync();
        }

        public async Task<Book> GetBookAsync(string id)
        {
            return await m_bookRepository.GetOneAsync(id);
        }

        public async Task<List<LookedUpAuthors>> GetBooksAsync(string id)
        {
            return await m_bookRepository.GetBookAsync(id);
        }
    }


}