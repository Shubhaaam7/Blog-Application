using BlogApplication.Models;

namespace BlogApplication.IBlogServices
{
    public interface IEmployee
    {

        public string CreateBlog(Employee employee);
        public List<Employee> EmployeeList();
        public Employee Edit(int blogId);
        public string Edit(Employee BlogM);
        public bool Delete(int EmpID);
    }
}
