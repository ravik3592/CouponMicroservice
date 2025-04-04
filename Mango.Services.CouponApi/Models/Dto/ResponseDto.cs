namespace Mango.Services.CouponApi.Models.Dto
{
    public class ResponseDto
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = string.Empty;
        public object Result { get; set; }
    }
}
