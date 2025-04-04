using AutoMapper;
using Mango.Services.CouponApi.Models;

namespace Mango.Services.CouponApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
