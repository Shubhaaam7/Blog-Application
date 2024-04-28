using BlogApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.IBlogServices
{
    public interface IBlog
    {
        public string CreateBlog(Blog BlogM);
        public List<Blog> BlogList();
        public Blog Edit(int blogId);
        public string Edit(Blog BlogM);
        public bool Delete(int blogId);
        public List<Dashboard> DashboardList();
    }
}
