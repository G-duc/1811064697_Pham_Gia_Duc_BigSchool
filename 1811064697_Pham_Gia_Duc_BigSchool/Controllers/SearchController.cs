using _1811064697_Pham_Gia_Duc_BigSchool.Models;
using _1811064697_Pham_Gia_Duc_BigSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1811064697_Pham_Gia_Duc_BigSchool.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext _dbContext;
        // GET: Search
        public SearchController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return RedirectToAction("Index", "Home");
            }
            var upcommingCourses = _dbContext.Courses
                .Include(s => s.Lecturer)
                .Include(s => s.Category)
                .Where(s =>
                s.Lecturer.Name.Contains(search) ||
                s.Category.Name.Contains(search) &&
                s.DateTime > DateTime.Now &&
                s.IsCanceled == false);

            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated,
                dataSearch = search,
            };
            return View(viewModel);
        }
    }
}