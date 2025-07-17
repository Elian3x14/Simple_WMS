using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.Users;

namespace TKS_intern_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserVM>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var userVMs = _mapper.Map<IEnumerable<UserVM>>(users);
            return Ok(userVMs);
        }

        // GET: api/Users/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // GET: api/Users/check-username?username=test123
        [HttpGet("check-username")]
        public async Task<IActionResult> CheckUsername([FromQuery] string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest("Username is required.");

            var isTaken = await _userRepository.IsUsernameTakenAsync(username);
            return Ok(new { isTaken });
        }

       
    }
}
