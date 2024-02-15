using Angular.NET.Data;
using Angular.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Angular.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly DbController _dbController;
        private readonly IConfiguration _configuration;

        public UsersController(ILogger<UsersController> logger, IConfiguration configuration) 
        {
            _logger = logger;
            _configuration = configuration;
            _dbController = new DbController(_configuration, _logger);
        }    

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dbController.ExecuteQuery<User>("SELECT * FROM dbo.Users").ToArray();
        }
    }
}
