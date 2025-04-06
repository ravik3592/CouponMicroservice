using Mango.Web.Models;
using Newtonsoft.Json;
using System.Text;

namespace Mango.Web.Services
{
    public class HttpService(IHttpClientFactory httpClientFactory) : IHttpService
    {
        public async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            try
            {
                var client = httpClientFactory.CreateClient("Mano API");

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();

                httpRequestMessage.Headers.Add("Accept", "application/json");

                httpRequestMessage.RequestUri = new Uri(requestDto.Url);

                if (requestDto.Data != null)
                {
                    httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                    httpRequestMessage.Method = requestDto.ApiType switch
                    {
                        ApiType.POST => HttpMethod.Post,
                        ApiType.PUT => HttpMethod.Put,
                        ApiType.DELETE => HttpMethod.Delete,
                        _ => HttpMethod.Get
                    };
                }

                HttpResponseMessage responseMessage = await client.SendAsync(httpRequestMessage);

                switch (responseMessage.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var apiContent = await responseMessage.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    case System.Net.HttpStatusCode.BadRequest:
                        return new() { IsSuccess = false, Message = "Bad Request" };
                    case System.Net.HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not found" };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal server error" };
                    default:
                        return new() { IsSuccess = false, Message = "Internal server error" };
                }
            }
            catch (Exception)
            {

                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Internal server error"
                };
            }
        }
    }
}
