using Angular.NET.Data;
using Angular.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Angular.NET.Controllers
{
    [ApiController]
    [Route("/usercontroller")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController>    _logger;
        private readonly DbController               _dbController;
        private readonly IConfiguration             _configuration;

        public UserController(ILogger<UserController> logger, IConfiguration configuration)
        {
            _logger             = logger;
            _configuration      = configuration;
            _dbController       = new DbController(_configuration, _logger);
        }

        [HttpGet]
        public IEnumerable<User>? Get()
        {
            try
            {
                return _dbController.ExecuteQuery<User>("SELECT * FROM dbo.Users");

            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
