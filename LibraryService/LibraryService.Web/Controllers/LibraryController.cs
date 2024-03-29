﻿using LibraryService.Web.Models;
using LibraryServiceReference;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryService.Web.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILogger<LibraryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(SearchType searchType, string searchString)
        {
            LibraryWebServiceSoapClient client = new LibraryWebServiceSoapClient(LibraryWebServiceSoapClient.EndpointConfiguration.LibraryWebServiceSoap);
            try
            {
                //LibraryWebServiceSoapClient client = new LibraryWebServiceSoapClient(LibraryWebServiceSoapClient.EndpointConfiguration.LibraryWebServiceSoap);

                if (!string.IsNullOrEmpty(searchString) && searchString.Length > 2)
                {
                    switch (searchType)
                    {
                        case SearchType.Author:
                            return View(new BookCategoryViewModel
                            {
                                Books = client.GetBooksByAuthor(searchString),
                            });
                        case SearchType.Title:
                            return View(new BookCategoryViewModel
                            {
                                Books = client.GetBooksByTitle(searchString),
                            });
                        case SearchType.Category:
                            return View(new BookCategoryViewModel
                            {
                                Books = client.GetBooksByCategory(searchString),
                            });
                        default: 
                            return View(new BookCategoryViewModel
                        {
                            Books = client.GetAllBooks()
                        });
                    }
                }
            }
            catch (Exception)
            {

            }
            return View(new BookCategoryViewModel
            {
                Books = client.GetAllBooks()
            });
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}