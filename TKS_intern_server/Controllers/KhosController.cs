using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TKS_intern_server.Data;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.Khos;

namespace TKS_intern_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhosController : ControllerBase
    {
        private readonly TKS_internContext _context;
        private readonly IKhoRepository _khoRepository;
        private readonly IMapper _mapper;

        public KhosController(TKS_internContext context, IMapper mapper, IKhoRepository khoRepository)
        {
            _context = context;
            _mapper = mapper;
            _khoRepository = khoRepository;
        }

        // GET: api/Khos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhoVM>>> GetKhos()
        {
            var list = await _khoRepository.GetAllAsync();
            var listMapped = _mapper.Map<IEnumerable<KhoVM>>(list);
            return Ok(listMapped);
        }

        // GET: api/Khos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KhoVM>> GetKho(int id)
        {
            var kho = await _khoRepository.GetByIdAsync(id);
            if (kho == null)
            {
                return NotFound(new { message = "Không tìm thấy kho." });
            }

            var resultVm = _mapper.Map<KhoVM>(kho);
            return Ok(resultVm);
        }

        // PUT: api/Khos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKho(int id, KhoUpdateVM vm)
        {
            if (id != vm.Id)
            {
                return BadRequest(new { message = "Id không khớp với dữ liệu gửi lên." });
            }

            var isDuplicate = await _khoRepository.ExistsByNameAsync(vm.TenKho, vm.Id);
            if (isDuplicate)
            {
                return BadRequest(new { message = "Tên kho đã tồn tại." });
            }

            var model = _mapper.Map<Kho>(vm);

            try
            {
                var updated = await _khoRepository.UpdateAsync(model);
                var resultVm = _mapper.Map<KhoVM>(updated);
                return Ok(resultVm);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        // POST: api/Khos
        [HttpPost]
        public async Task<ActionResult<KhoVM>> PostKho(KhoCreateVM vm)
        {
            var isDuplicate = await _khoRepository.ExistsByNameAsync(vm.TenKho);
            if (isDuplicate)
            {
                return BadRequest(new { message = "Tên kho đã tồn tại." });
            }

            var model = _mapper.Map<Kho>(vm);
            var created = await _khoRepository.CreateAsync(model);
            var createdVm = _mapper.Map<KhoVM>(created);

            return CreatedAtAction(nameof(GetKho), new { id = createdVm.Id }, createdVm);
        }

        // DELETE: api/Khos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKho(int id)
        {
            var result = await _khoRepository.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound(new { message = "Không tìm thấy kho cần xoá." });
        }
    }
}
