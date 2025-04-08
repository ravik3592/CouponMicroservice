using Mango.Web.Models;

namespace Mango.Web.Services
{
    public interface ICouponService
    {
        Task<ResponseDto> GetAllCouponsAsync();
        Task<ResponseDto> GetCouponByIdAsync(int couponId);
        Task<ResponseDto> GetCouponByCodeAsync(string couponCode);
        Task<ResponseDto> AddCouponAsync(CouponDto couponDto);
        Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto);
        Task<ResponseDto> DeleteCouponAsync(int couponId);
    }
}
