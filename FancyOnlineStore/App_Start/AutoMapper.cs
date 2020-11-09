using AutoMapper;
using DAL.Models;
using FancyOnlineStore.Models;

namespace FancyOnlineStore
{
    public static class AutoMapper
    {
        public static IMapper Mapper { get; }

        public static void Initialize()
        {

        }
        static AutoMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<ProductDto, ProductViewModel>();
                    cfg.CreateMap<ProductViewModel, ProductDto>();
                    cfg.CreateMap<BrandDto, BrandViewModel>();
                });
            Mapper = config.CreateMapper();
        }
    }
}