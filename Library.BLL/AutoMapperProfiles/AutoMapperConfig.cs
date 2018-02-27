using AutoMapper;

namespace Library.BLL.AutoMapperProfiles
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<BookProfile>();
                cfg.AddProfile<BrochureProfile>();
                cfg.AddProfile<MagazineProfile>();
                cfg.AddProfile<PublisherProfile>();
                cfg.AddProfile<AuthorProfile>();
            });
        }
    }
}
