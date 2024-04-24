using BlogApplication.Constants;
using BlogApplication.Data;
using BlogApplication.IBlogServices;
using BlogApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Serilog;
using System;
using System.Data;
using System.Text;
namespace BlogApplication.BlogService_Implemetation
{
    public class BlogServiceImplementation : IBlog
    {
        private readonly ApplicationDbContext context;
       
        public BlogServiceImplementation(ApplicationDbContext _context)
        {
            context = _context;
        }

        #region List
        /// <summary>
        /// BlogPost API fetch all blog post that have been created
        /// </summary>
        /// <returns></returns>
        public List<Blog> BlogList()
        {
            List<Blog> outputList = new List<Blog>();
            try
            {
                var  List = context.BlogDetails.Where(u => u.Isdeleted == false).
                    OrderByDescending(b => b.Id).
                    AsNoTracking().
                    ToList();

                if (List is not null)
                {
                    foreach (var i in List)
                    {
                        Blog temp = new Blog();
                        temp.Id = i.Id;
                        temp.Title = i.Title;
                        temp.AutherName = i.AutherName;
                        System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("<[^>]*>");
                        temp.Contents = rx.Replace(i.Contents, "");
                        temp.PublicationDate = i.PublicationDate;
                        outputList.Add(temp);
                    }
                    return outputList;
                }
                else 
                {
                    Log.Information("Controller:BlogServiceImplementation  Method:BlogList" +"List Fetched Successfully");
                
                    return outputList;
                }    
            }
            catch (Exception ex) 
            {
                Log.Error("Controller:BlogServiceImplementation  Method:BlogList"+ ex);
                throw ex;

            }
        }
        #endregion

        #region Create
        /// <summary>
        /// CreateBlog service add new blog post with blog related details
        /// </summary>
        /// <param name="BlogM"></param>
        /// <returns></returns>
        public string  CreateBlog(Blog BlogM)
        {
            string output=string.Empty;
            try
            {
                Blog blog = new Blog();
                blog.AutherName = BlogM.AutherName;
                blog.Title = BlogM.Title;
                blog.Contents = BlogM.Contents;
                blog.PublicationDate = BlogM.PublicationDate;
                blog.CreatedDate = DateTime.Now;
                blog.CreatedBy = "";
                context.BlogDetails.Add(blog);
                context.SaveChanges();
                output = BlogConstant.SUCCESSMESSAGE;

                Log.Information("Controller:BlogServiceImplementation  Method:Create" + "Blog created Successfully");
                return output;
            }
            catch(Exception ex)
            {
                Log.Error("Controller:BlogServiceImplementation  Method:Create" + ex);
                throw ex;
            }   
        }

        #endregion

        #region Edit
        /// <summary>
        /// Edit blogId
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public Blog Edit(int blogId)
        {
            Blog Model = new Blog();
            if (blogId > 0)
            {
                var BlogData = context.BlogDetails.Where(u=> u.Id == blogId).FirstOrDefault();
                Model.Id = BlogData.Id;
                Model.AutherName=BlogData.AutherName;
                Model.Title = BlogData.Title;
                Model.Contents = BlogData.Contents;
                Model.PublicationDate=BlogData.PublicationDate; 
            }
           
            return Model;
        }

        /// <summary>
        /// Edit Service update the specific blog post with updated data
        /// </summary>
        /// <param name="BlogM"></param>
        /// <returns></returns>
        public string Edit(Blog BlogM)
        {
            string output = "";
            var blog = context.BlogDetails.Where(u => u.Id == BlogM.Id).FirstOrDefault();
            try
            {
                if (blog is not null)
                {
                    blog.Id = BlogM.Id;
                    blog.AutherName = BlogM.AutherName;
                    blog.Title = BlogM.Title;
                    blog.Contents = BlogM.Contents;
                    blog.PublicationDate = BlogM.PublicationDate;
                    blog.UpdatedDate = DateTime.Now;
                    context.BlogDetails.Update(blog); 
                    context.SaveChanges();

                    Log.Information("Controller:BlogServiceImplementation  Method:Edit" + "Blog updated successfully");
                    output = BlogConstant.SUCCESSMESSAGE;
                }
                return output;
            }
            catch(Exception ex) 
            {
                Log.Error("Controller:BlogServiceImplementation  Method:Edit" + ex);
                throw ex;           
            }   
        }
        #endregion

        #region  Delete
        /// <summary>
        /// Delete Service from blog list
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(int blogId)
        {
            bool output=false;
            if(blogId != 0)
            {
                var data = context.BlogDetails.Where(u => u.Id == blogId).FirstOrDefault();
                if (data!=null) 
                {
                    context.BlogDetails.Remove(data);
                    context.SaveChanges();
                    output = true;
                    return output;
                }
            }
            return output;
        }
        #endregion
    }
}
