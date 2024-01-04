using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.MessageDtos;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _DefaultContactComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultContactComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
		
		[HttpPost]
		public async Task<IViewComponentResult> InvokeAsync(CreateMessageDto createMessageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7264/api/Message", content);
            if(responseMessage.IsSuccessStatusCode)
            {

                return View("Index");
            }
            return View();

        }
        
    }
}
