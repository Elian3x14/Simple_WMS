using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TKS_intern_server.Data;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.KhoUsers;

namespace TKS_intern_shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoUsersController : ControllerBase
    {
        private readonly TKS_internContext _context;
        private readonly IKhoUserRepository _khoUserRepository;
        private readonly IMapper _mapper;

        public KhoUsersController(TKS_internContext context, IMapper mapper, IKhoUserRepository khoUserRepository)
        {
            _context = context;
            _mapper = mapper;
            _khoUserRepository = khoUserRepository;
        }

        // GET: api/KhoUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhoUserVM>>> GetAll()
        {
            var list = await _khoUserRepository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<KhoUserVM>>(list);
            return Ok(mapped);
        }

        // GET: api/KhoUsers/user/admin
        [HttpGet("user/{maDangNhap}")]
        public async Task<ActionResult<IEnumerable<KhoUserVM>>> GetByUser(string maDangNhap)
        {
            var list = await _khoUserRepository.GetByUserAsync(maDangNhap);
            var mapped = _mapper.Map<IEnumerable<KhoUserVM>>(list);
            return Ok(mapped);
        }

        // POST: api/KhoUsers
        [HttpPost]
        public async Task<ActionResult<KhoUserVM>> Post(KhoUserCreateVM vm)
        {
            var isExisted = await _khoUserRepository.ExistsAsync(vm.MaDangNhap, vm.KhoId);
            if (isExisted)
                return BadRequest(new { message = "Người dùng đã được phân quyền kho này." });

            var model = _mapper.Map<KhoUser>(vm);
            var created = await _khoUserRepository.CreateAsync(model);
            var resultVm = _mapper.Map<KhoUserVM>(created);
            return CreatedAtAction(nameof(GetByUser), new { maDangNhap = resultVm.MaDangNhap }, resultVm);
        }

        // DELETE: api/KhoUsers?maDangNhap=abc&khoId=1
        [HttpDelete]
        public async Task<IActionResult> Delete(string maDangNhap, int khoId)
        {
            var deleted = await _khoUserRepository.DeleteAsync(maDangNhap, khoId);
            if (deleted)
                return NoContent();
            return NotFound(new { message = "Không tìm thấy phân quyền kho-user cần xoá." });
        }

        // GET: api/KhoUsers/kho/1
        [HttpGet("kho/{khoId}")]
        public async Task<ActionResult<IEnumerable<KhoUserVM>>> GetByKho(int khoId)
        {
            var list = await _khoUserRepository.GetByKhoAsync(khoId);
            var mapped = _mapper.Map<IEnumerable<KhoUserVM>>(list);
            return Ok(mapped);
        }

    }
}
