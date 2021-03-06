﻿using StoreSample.Web.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StoreSample.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string query = null)
        {
            // this is where we'll go the DB
            // generate the model
            var books = new List<Book>();

            using (var storeSampleDatabase = new Entities())
            {
                var bookResults = storeSampleDatabase.Books.AsQueryable();

                if (!string.IsNullOrEmpty(query))
                {
                    var lowerCaseQuery = query.ToLower();

                    bookResults = bookResults.Where(book => book.Title.ToLower().Contains(lowerCaseQuery));
                }

                books = bookResults.ToList();
            }

            return View(books);
        }
    }
}