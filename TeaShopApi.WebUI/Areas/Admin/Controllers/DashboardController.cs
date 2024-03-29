﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DashboardController : Controller
    {
        
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7264/api/Statistics/GetDrinkAveragePrice");
            var JsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.v1= JsonData1;

            var responseMessage2 = await client.GetAsync("https://localhost:7264/api/Statistics/GetDrinkCount");
            var JsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.v2 = JsonData2;

            var responseMessage3 = await client.GetAsync("https://localhost:7264/api/Statistics/GetLastDrinkName");
            var JsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.v3 = JsonData3;

            var responseMessage4 = await client.GetAsync("https://localhost:7264/api/Statistics/GetMaxPriceDrink");
            var JsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.v4 = JsonData4;

            return View();
        }
    }
}
