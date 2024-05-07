using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApplication.Data;
using BlogApplication.IBlogServices;
using BlogApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Controllers
{
    public class DashboardController : Controller
    {

        // Created Reference of ApplicationDbContext class
        private readonly ApplicationDbContext context;

        //Created Reference of Iblog service  Interface
        private readonly IBlog _blogService;

        //Created Reference of Toaster service  Interface
        private readonly INotyfService _toastr;
        public DashboardController(ApplicationDbContext _context,
                              IBlog blogService,
                              INotyfService toastr)
        {
            context = _context;
            _blogService = blogService;
            _toastr = toastr;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public List<object> List()
        {

            var data = context.MonthWiseData.FromSqlInterpolated($"MonthWiseData").ToList();

            List<object> output = new List<object>();
            //var List = _blogService.DashboardList();
            //_blogService.DashboardList().Select(x => x.MonthName).ToList();
            //_blogService.DashboardList().Select(x => x.TotalSales).ToList();
            List<int> salesnumber = new List<int>();
            List<string> labels = new List<string>();

            foreach (var item in data) 
            {
                output.Add(item.MonthName);
                output.Add(item.MonthCount);
            }


            
            return output;

            
        }

    }
}
