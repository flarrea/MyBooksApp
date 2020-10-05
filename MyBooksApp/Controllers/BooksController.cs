using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBooksApp.Data;
using MyBooksApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyBooksApp.Controllers
{
    public class BooksController : Controller
    {
        private AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            //Determine the next ID
            var newID = _context.Books.Select(x => x.Id).Max() + 1;
            book.Id = newID;

            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }

    }
}
