using LibraryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryService.Services.Impl
{
    public class LibraryRepository : ILibraryRepositoryService
    {
        private readonly ILibraryDatabaseContextService _context;
        public LibraryRepository(ILibraryDatabaseContextService context)
        {
            _context = context;
        }

        public IList<Book> GetAll()
        {
            try
            {
                return _context.Books.ToList();
            }
            catch (Exception ex)
            {
                return new List<Book>();
            }            
        }

        public IList<Book> GetByAuthor(string author)
        {
            try
            {
                return _context.Books.Where(book =>
            book.Authors.Where(auth => auth.Name.ToLower().Contains(author.ToLower())).Count() > 0).ToList();
            }
            catch (Exception ex)
            {
                return new List<Book>();
            }
        }

        public IList<Book> GetByCategory(string category)
        {
            try
            {
                return _context.Books.Where(book => book.Category.ToLower().Contains(category.ToLower())).ToList();

            }
            catch (Exception ex)
            {
                return new List<Book>();
            }
        }

        public IList<Book> GetByTitle(string title)
        {
            try
            {
                return _context.Books.Where(book => book.Title.ToLower().Contains(title.ToLower())).ToList();

            }
            catch (Exception ex)
            {
                return new List<Book>();
            }
        }
    }
}