using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class DrinkController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public DrinkController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7264/api/Drinks");
			if (responseMessage.IsSuccessStatusCode)
			{
				var JsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDrinkDtos>>(JsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateDrink()
		{
			return View();
		}
		[HttpPost]

		public async Task<IActionResult> CreateDrink(CreateDrinkDto createDrinkDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(createDrinkDto);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7264/api/Drinks", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteDrink(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responstMessage = await client.DeleteAsync("https://localhost:7264/api/Drinks?id="+id);
			if(responstMessage.IsSuccessStatusCode) 
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateDrink(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7264/api/Drinks/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateDrinkDtos>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> UpdateDrink(UpdateDrinkDtos updateDrinkDtos)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateDrinkDtos);
			StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:7264/api/Drinks", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

    }
}
