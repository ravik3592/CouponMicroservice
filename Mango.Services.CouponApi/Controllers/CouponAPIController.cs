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

        [HttpGet]
        [Route("GetByCode/:{code}")]
        public IActionResult Get(string code)
        {
            var response = new ResponseDto();

            try
            {
                var coupon = appDbContext.Coupons.FirstOrDefault(c => c.CouponCode.Equals(code));
                response.Result = mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("AddCoupon")]
        public IActionResult Add([FromBody] CouponDto couponDto)
        {
            var response = new ResponseDto();
            try
            {
                var couponObj = mapper.Map<Coupon>(couponDto);
                appDbContext.Coupons.Add(couponObj);
                appDbContext.SaveChanges();
                response.Result = mapper.Map<CouponDto>(couponObj);
                response.Message = "Coupon added successfully";
            } 
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateCoupon")]
        public IActionResult Update([FromBody] CouponDto couponDto)
        {
            var response = new ResponseDto();
            try
            {
                var couponObj = mapper.Map<Coupon>(couponDto);
                appDbContext.Coupons.Update(couponObj);
                appDbContext.SaveChanges();

                response.Result = mapper.Map<CouponDto>(couponObj);
                response.Message = "Coupon updated successfully";
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteCoupon")]
        public IActionResult Delete(int id)
        {
            var response = new ResponseDto();
            try
            {
                var coupon = appDbContext.Coupons.FirstOrDefault(c => c.CouponId == id);
                if(coupon == null)
                {
                    response.StatusCode = 404;
                    response.Message = "Coupon not found";
                    return NotFound(response);
                }
                appDbContext.Coupons.Remove(coupon);
                appDbContext.SaveChanges();
                response.Message = "Coupon deleted";
            }
            catch(Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
