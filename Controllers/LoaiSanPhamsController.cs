using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.LoaiSanPhams;
using TKS_intern_server.Repositories.Interfaces;

namespace TKS_intern_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSanPhamsController : ControllerBase
    {
        private readonly ILoaiSanPhamRepository _loaiSanPhamRepository;
        private readonly IMapper _mapper;

        public LoaiSanPhamsController(ILoaiSanPhamRepository loaiSanPhamRepository, IMapper mapper)
        {
            _loaiSanPhamRepository = loaiSanPhamRepository;
            _mapper = mapper;
        }

        // GET: api/LoaiSanPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSanPhamVM>>> GetLoaiSanPhams()
        {
            var list = await _loaiSanPhamRepository.GetAllAsync();
            var listMapped = _mapper.Map<IEnumerable<LoaiSanPhamVM>>(list);
            return Ok(listMapped);
        }

        // GET: api/LoaiSanPhams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiSanPhamVM>> GetLoaiSanPham(int id)
        {
            var loai = await _loaiSanPhamRepository.GetByIdAsync(id);
            if (loai == null)
                return NotFound(new { message = "Không tìm thấy loại sản phẩm." });

            var result = _mapper.Map<LoaiSanPhamVM>(loai);
            return Ok(result);
        }

        // POST: api/LoaiSanPhams
        [HttpPost]
        public async Task<ActionResult<LoaiSanPhamVM>> PostLoaiSanPham(LoaiSanPhamCreateVM vm)
        {
            if (await _loaiSanPhamRepository.ExistsByMaAsync(vm.MaLoaiSanPham))
                return BadRequest(new { message = "Mã loại sản phẩm đã tồn tại." });

            if (await _loaiSanPhamRepository.ExistsByTenAsync(vm.TenLoaiSanPham))
                return BadRequest(new { message = "Tên loại sản phẩm đã tồn tại." });

            var model = _mapper.Map<LoaiSanPham>(vm);
            var created = await _loaiSanPhamRepository.CreateAsync(model);
            var createdVm = _mapper.Map<LoaiSanPhamVM>(created);

            return CreatedAtAction(nameof(GetLoaiSanPham), new { id = createdVm.Id }, createdVm);
        }

        // PUT: api/LoaiSanPhams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiSanPham(int id, LoaiSanPhamUpdateVM vm)
        {
            if (id != vm.Id)
                return BadRequest(new { message = "Id không khớp với dữ liệu gửi lên." });

            if (await _loaiSanPhamRepository.ExistsByMaAsync(vm.MaLoaiSanPham, vm.Id))
                return BadRequest(new { message = "Mã loại sản phẩm đã tồn tại." });

            if (await _loaiSanPhamRepository.ExistsByTenAsync(vm.TenLoaiSanPham, vm.Id))
                return BadRequest(new { message = "Tên loại sản phẩm đã tồn tại." });

            var model = _mapper.Map<LoaiSanPham>(vm);

            try
            {
                var updated = await _loaiSanPhamRepository.UpdateAsync(model);
                var resultVm = _mapper.Map<LoaiSanPhamVM>(updated);
                return Ok(resultVm);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        // DELETE: api/LoaiSanPhams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiSanPham(int id)
        {
            var deleted = await _loaiSanPhamRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = "Không tìm thấy loại sản phẩm cần xoá." });

            return NoContent();
        }
    }
}
