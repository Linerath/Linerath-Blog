﻿using AutoMapper;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.Web.Models;
using Linerath_Blog.Web.ViewModels;

namespace Linerath_Blog.Web.Infrastructure.Automapper
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryModel>()
            //.ForMember(dest => dest.Count, opt => opt.Ignore())
                ;
        }
    }
}