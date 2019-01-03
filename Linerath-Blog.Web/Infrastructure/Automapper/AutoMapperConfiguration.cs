using AutoMapper;

namespace Linerath_Blog.Web.Infrastructure.Automapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ArticleMappingProfile());
            });
        }
    }
}