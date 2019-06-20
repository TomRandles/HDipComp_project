using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Newtonsoft.Json;
using TRHDipComp_Project.Models;


namespace TRHDipComp_Project.Pages
{
    public class GetWeatherReportModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        private string APIKey = "1dfc616b32f88edc2de2243c4631d723";

        [BindProperty]
        public string Result { get; set; } = "";

        public ResponseWeather ResponseWeather { get; private set; }

        public GetWeatherReportModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var client = _clientFactory.CreateClient();

            try
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org");
                HttpResponseMessage response = await client.GetAsync($"/data/2.5/weather?id=2964179" +
                                                                      "&appid="+ APIKey + "&units=metric");
                response.EnsureSuccessStatusCode();

                Result = await response.Content.ReadAsStringAsync();
                ResponseWeather = JsonConvert.DeserializeObject<ResponseWeather>(Result);
                return Page();
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting data from jsonplaceholder {httpRequestException.Message}");
            }
        }
    }
}