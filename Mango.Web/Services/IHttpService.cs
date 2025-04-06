using Mango.Web.Models;

namespace Mango.Web.Services
{
    public interface IHttpService
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
