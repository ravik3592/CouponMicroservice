using Mango.Web.Models;
using Mango.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController(ICouponService couponService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var couponList = new List<CouponDto>();
            var responseDto = await couponService.GetAllCouponsAsync();

            if (responseDto.Result is not null && responseDto.IsSuccess)
            {
                couponList = JsonConvert.DeserializeObject<List<CouponDto>>(responseDto.Result.ToString());
            }
            return View(couponList);
        }
    }
}
