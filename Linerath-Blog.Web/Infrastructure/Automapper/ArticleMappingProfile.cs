using AutoMapper;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.Web.ViewModels;

namespace Linerath_Blog.Web.Infrastructure.Automapper
{
    public class ArticleMappingProfile : Profile
    {
        public ArticleMappingProfile()
        {
            var map = CreateMap<Article, ArticleSummaryViewModel>()
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                ;
        }
    }
}