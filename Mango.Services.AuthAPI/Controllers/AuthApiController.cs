using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController(IAuthService authService) : ControllerBase
    {

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var responseDto = new ResponseDto();
            var response = await authService.Login(loginRequestDto);

            if (response.User is null) 
            {
                responseDto.IsSuccess = false;
            }

            return Ok(responseDto);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var responseDto = new ResponseDto();
            var response = await authService.Register(registerRequestDto);
            if(!string.IsNullOrWhiteSpace(response))
            {
                responseDto.Message = response;
                responseDto.IsSuccess = false; 
            }
            return Ok(responseDto);
        }
    }
}
