using BlogApplication.Data;
using BlogApplication.IBlogServices;
using BlogApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BlogApplication.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IEmployee _employee;

        public EmployeesController(ApplicationDbContext context, IEmployee employee)
        {
            _context = context;
            _employee = employee;
        }

        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult List(int pg=1)
        {
            var List = _employee.EmployeeList();

            const int pageSize = 20;
            if (pg < 1)
                pg = 1;


            int rescCount = List.Count();

            var pager = new PaginatedList(rescCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = List.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.pager = pager;
            return View(data);
        }

        
    }
}
