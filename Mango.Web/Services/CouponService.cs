using Mango.Web.Models;
using Mango.Web.Utility;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Services
{
    public class CouponService(IHttpService httpService) : ICouponService
    {
        public async Task<ResponseDto> AddCouponAsync(CouponDto couponDto)
        {
            var requestDto = new RequestDto
            {
                ApiType = ApiType.POST,
                Url = SD.CouponAPIBase + "AddCoupon",
                Data = couponDto
            };
            return await httpService.SendAsync(requestDto);
        }

        public async Task<ResponseDto> DeleteCouponAsync(int couponId)
        {
            var requestDto = new RequestDto
            {
                ApiType = ApiType.DELETE,
                Url = SD.CouponAPIBase + "DeleteCoupon/" + couponId
            };
            return await httpService.SendAsync(requestDto);
        }

        public async Task<ResponseDto> GetAllCouponsAsync()
        {
            var requestDto = new RequestDto
            {
                ApiType = ApiType.GET,
                Url = SD.CouponAPIBase + "GetAll"
            };
            return await httpService.SendAsync(requestDto);
        }

        public async Task<ResponseDto> GetCouponByCodeAsync(string couponCode)
        {
            var requestDto = new RequestDto
            {
                ApiType = ApiType.GET,
                Url = SD.CouponAPIBase + "GetByCode" + couponCode
            };
            return await httpService.SendAsync(requestDto);
        }

        public async Task<ResponseDto> GetCouponByIdAsync(int couponId)
        {
            var requestDto = new RequestDto
            {
                ApiType = ApiType.GET,
                Url = SD.CouponAPIBase + "Get/" + couponId
            };
            return await httpService.SendAsync(requestDto);
        }

        public async Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto)
        {
            var requestDto = new RequestDto
            {
                ApiType = ApiType.PUT,
                Url = SD.CouponAPIBase + "UpdateCoupon",
                Data = couponDto
            };
            return await httpService.SendAsync(requestDto);
        }
    }
}
