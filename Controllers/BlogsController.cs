﻿
using AspNetCoreHero.ToastNotification.Abstractions;
using BlogApplication.Constants;
using BlogApplication.Data;
using BlogApplication.IBlogServices;
using BlogApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;


namespace BlogApplication.Controllers
{
   [AllowAnonymous]
    public class BlogsController : Controller
    {
        // Created Reference of ApplicationDbContext class
        private readonly ApplicationDbContext context; 

        //Created Reference of Iblog service  Interface
        private readonly IBlog _blogService;

        //Created Reference of Toaster service  Interface
        private readonly INotyfService _toastr;


        public BlogsController(ApplicationDbContext _context, 
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
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }


        [HttpPost]
        public async Task <IActionResult> Create(Blog BlogModel)
        {
            if (ModelState.IsValid)
            {
                var status =  _blogService.CreateBlog(BlogModel);


                return RedirectToAction(BlogConstant.LIST);
            }
            else
            {
                return RedirectToAction(BlogConstant.Create);
            }
        }
        [HttpGet]
        public IActionResult List()
        {
           
            var List = _blogService.BlogList();
            return View(List);
        }
        [HttpGet]
        [Route("Blogs/Edit/{blogId:int}")]
        public IActionResult Edit(int blogId)
        {
            Blog modelData = new Blog();
            if (blogId != 0)
            {
                var data = _blogService.Edit(blogId);
                modelData.Id = data.Id;
                modelData.Title = data.Title;
                modelData.AutherName = data.AutherName;
                modelData.PublicationDate = data.PublicationDate;
                modelData.Contents = data.Contents;
            }
            return View(modelData);
        }

        [HttpPost]
        public IActionResult Edit(Blog Model)
        {
            if (ModelState.IsValid)
            {
                var Status = _blogService.Edit(Model);
                if (Status == BlogConstant.SUCCESSMESSAGE)
                {
                    _toastr.Success(BlogConstant.SUCCESSMESSAGE);
                    return RedirectToAction(BlogConstant.LIST);
                }

            }
                return RedirectToAction(BlogConstant.Edit, Model.Id);
            
        }

        public IActionResult Delete(int Id)
        {
            if (Id != 0)
            {
                var status = _blogService.Delete(Id);
            }
            return RedirectToAction(BlogConstant.LIST);
        }


        public IActionResult View(int Id)
        {
            Blog modelData = new Blog();
            if (Id != 0)
            {
                var data = _blogService.Edit(Id);
                System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("<[^>]*>");
                modelData.Id = data.Id;
                modelData.Title = data.Title;
                modelData.AutherName = data.AutherName;
                modelData.PublicationDate = data.PublicationDate;
                modelData.Contents = rx.Replace(data.Contents, "");
            }
            ViewBag.ReadMore = modelData;
            return View(modelData);
        }
    }
}

