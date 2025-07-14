using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.NhaCungCaps;
using TKS_intern_server.Repositories.Interfaces;

namespace TKS_intern_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapsController : ControllerBase
    {
        private readonly INhaCungCapRepository _nhaCungCapRepository;
        private readonly IMapper _mapper;

        public NhaCungCapsController(INhaCungCapRepository nhaCungCapRepository, IMapper mapper)
        {
            _nhaCungCapRepository = nhaCungCapRepository;
            _mapper = mapper;
        }

        // GET: api/NhaCungCaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhaCungCapVM>>> GetAll()
        {
            var list = await _nhaCungCapRepository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<NhaCungCapVM>>(list);
            return Ok(mapped);
        }

        // GET: api/NhaCungCaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhaCungCapVM>> GetById(int id)
        {
            var entity = await _nhaCungCapRepository.GetByIdAsync(id);
            if (entity == null)
                return NotFound(new { message = "Không tìm thấy nhà cung cấp." });

            return Ok(_mapper.Map<NhaCungCapVM>(entity));
        }

        // POST: api/NhaCungCaps
        [HttpPost]
        public async Task<ActionResult<NhaCungCapVM>> Create(NhaCungCapCreateVM vm)
        {
            if (await _nhaCungCapRepository.ExistsByNameAsync(vm.TenNhaCungCap))
                return BadRequest(new { message = "Tên nhà cung cấp đã tồn tại." });

            var model = _mapper.Map<NhaCungCap>(vm);
            var created = await _nhaCungCapRepository.CreateAsync(model);
            var result = _mapper.Map<NhaCungCapVM>(created);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/NhaCungCaps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NhaCungCapUpdateVM vm)
        {
            if (id != vm.Id)
                return BadRequest(new { message = "Id không khớp với dữ liệu gửi lên." });

            if (await _nhaCungCapRepository.ExistsByNameAsync(vm.TenNhaCungCap, vm.Id))
                return BadRequest(new { message = "Tên nhà cung cấp đã tồn tại." });

            var model = _mapper.Map<NhaCungCap>(vm);
            try
            {
                var updated = await _nhaCungCapRepository.UpdateAsync(model);
                var result = _mapper.Map<NhaCungCapVM>(updated);
                return Ok(result);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        // DELETE: api/NhaCungCaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _nhaCungCapRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = "Không tìm thấy nhà cung cấp để xoá." });

            return NoContent();
        }
    }
}
