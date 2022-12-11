using LibraryService.Models;
using LibraryService.Services;
using LibraryService.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LibraryService
{
    /// <summary>
    /// Summary description for LibraryWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LibraryWebService : System.Web.Services.WebService
    {
        private ILibraryRepositoryService _reposotory;

        public LibraryWebService()
        {
            _reposotory = new LibraryRepository(new LibraryDatabaseContext());    
        }

        [WebMethod]
        public Book[] GetAllBooks()
        {
            return _reposotory.GetAll().ToArray();
        }

        [WebMethod]
        public Book[] GetBooksByTitle(string title)
        {
           return _reposotory.GetByTitle(title).ToArray();
        }

        [WebMethod]
        public Book[] GetBooksByAuthor(string author)
        {
            return _reposotory.GetByAuthor(author).ToArray();
        }

        [WebMethod]
        public Book[] GetBooksByCategory(string category)
        {
            return _reposotory.GetByCategory(category).ToArray();
        }
    }
}
