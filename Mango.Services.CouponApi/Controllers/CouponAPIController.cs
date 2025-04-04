using AutoMapper;
using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Models;
using Mango.Services.CouponApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController(AppDbContext appDbContext, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var response = new ResponseDto();
            try
            {
                var coupons = appDbContext.Coupons.ToList();
                response.Result = mapper.Map<List<CouponDto>>(coupons);
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("Get/:{id}")]
        public IActionResult Get(int id)
        {
            var response = new ResponseDto();
            try
            {
                var coupon = appDbContext.Coupons.FirstOrDefault(c => c.CouponId == id);

                response.Result = mapper.Map<CouponDto>(coupon);
                
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
