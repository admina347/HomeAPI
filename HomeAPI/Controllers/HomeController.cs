using System.Text;
using AutoMapper;
using HomeApi.Contracts.Models;
using HomeAPI.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HomeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        // Ссылка на объект конфигурации
        private IOptions<HomeOptions> _options;
        //AutoMApper
        private IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        // Инициализация конфигурации при вызове конструктора
        public HomeController(ILogger<HomeController> logger, IOptions<HomeOptions> options, IMapper mapper)
        {
            _logger = logger;
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод для получения информации о доме
        /// </summary>
        [HttpGet] // Для обслуживания Get-запросов
        [Route("info")] // Настройка маршрута с помощью атрибутов
        public IActionResult Info()
        {
            // Получим запрос, "смапив" конфигурацию на модель запроса
            var infoResponse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);
            // Вернём ответ
            return StatusCode(200, infoResponse);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}