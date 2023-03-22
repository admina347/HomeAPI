using AutoMapper;
using HomeAPI.Configuration;
using HomeAPI.Contracts.Devices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HomeAPI.Controllers
{
    /// <summary>
    /// Контроллер статусов устройств
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;
        private readonly ILogger<DevicesController> _logger;

        public DevicesController(ILogger<DevicesController> logger, IOptions<HomeOptions> options, IMapper mapper)
        {
            _logger = logger;
            _options = options;
            _mapper = mapper;
        }
        /// <summary>
        /// Просмотр списка подключенных устройств
        /// </summary>
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return StatusCode(200, "Устройства отсутствуют");
        }

        /// <summary>
        /// Добавление нового устройства
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(
            [FromBody] 
            AddDeviceRequest request
        )
        {
            return StatusCode(200, $"Устройство {request.Name} добавлено!");
        }
    }
}