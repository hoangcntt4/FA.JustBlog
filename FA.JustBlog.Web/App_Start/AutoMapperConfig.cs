using FA.JustBlog.ViewModels.Tag;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Post;
using FA.JustBlog.ViewModels.Category;
using FA.JustBlog.ViewModels.Comment;

namespace FA.JustBlog.Web.App_Start
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
          
            CreateMap<Post, CreatePostViewModel>().ReverseMap();
            CreateMap<Category, CreateCategoryViewModel>().ReverseMap();
            CreateMap<Tag, CreateTagViewModel>().ReverseMap();
            CreateMap<Comment, CreateCommentViewAdminModel>().ReverseMap();
        }

    }
}