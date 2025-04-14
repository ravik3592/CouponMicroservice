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

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                var responseDto = await couponService.AddCouponAsync(couponDto);
                if (responseDto.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, responseDto.Message);
                }
            }
            return View(couponDto);
        }

        public async Task<IActionResult> Detail(int Id)
        {   
            var couponDto = new CouponDto();
            var responseDto = await couponService.GetCouponByIdAsync(Id);
            if(responseDto is not null && responseDto.IsSuccess)
            {
                couponDto = JsonConvert.DeserializeObject<CouponDto>(responseDto.Result.ToString());
                return View(couponDto);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CouponDto couponDto)
        {
            var responseDto = await couponService.DeleteCouponAsync(couponDto.CouponId);
            if (responseDto is not null && responseDto.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
