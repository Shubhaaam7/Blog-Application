using BlogApplication.Data;
using BlogApplication.IBlogServices;
using BlogApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.BlogService_Implemetation
{
    public class IEmployeeImplemetation : IEmployee
    {
        private readonly ApplicationDbContext context;

        public IEmployeeImplemetation(ApplicationDbContext _context)
        {
            context = _context;
        }

        public List<Employee> EmployeeList()
        {
            var empList=context.Employee.AsNoTracking().ToList();
         

            if (empList.Count > 0)
            {
              
                 return empList;
            }
            return Enumerable.Empty<Employee>().ToList(); 
        }

        public string CreateBlog(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int EmpID)
        {
            throw new NotImplementedException();
        }

        public Employee Edit(int blogId)
        {
            throw new NotImplementedException();
        }

        public string Edit(Employee BlogM)
        {
            throw new NotImplementedException();
        }
    }
}
