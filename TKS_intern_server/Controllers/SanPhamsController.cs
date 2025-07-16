using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.BaoCaos;
using TKS_intern_shared.ViewModels.SanPhams;

namespace TKS_intern_shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamsController : ControllerBase
    {
        private readonly ISanPhamRepository _sanPhamRepository;
        private readonly ILoaiSanPhamRepository _loaiSanPhamRepository;
        private readonly IDonViTinhRepository _donViTinhRepository;
        private readonly IMapper _mapper;

        public SanPhamsController(
            ISanPhamRepository sanPhamRepository,
            ILoaiSanPhamRepository loaiSanPhamRepository,
            IDonViTinhRepository donViTinhRepository,
            IMapper mapper)
        {
            _sanPhamRepository = sanPhamRepository;
            _loaiSanPhamRepository= loaiSanPhamRepository;
            _donViTinhRepository = donViTinhRepository;
            _mapper = mapper;
        }

        // GET: api/SanPhams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPhamVM>>> GetSanPhams()
        {
            var list = await _sanPhamRepository.GetAllAsync();
            var listMapped = _mapper.Map<IEnumerable<SanPhamVM>>(list);
            return Ok(listMapped);
        }

        // GET: api/SanPhams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPhamVM>> GetSanPham(int id)
        {
            var item = await _sanPhamRepository.GetByIdAsync(id);
            if (item == null)
                return NotFound(new { message = "Không tìm thấy sản phẩm." });

            var result = _mapper.Map<SanPhamVM>(item);
            return Ok(result);
        }

        // POST: api/SanPhams
        [HttpPost]
        public async Task<ActionResult<SanPhamVM>> PostSanPham(SanPhamCreateVM vm)
        {
            if (await _sanPhamRepository.ExistsByMaAsync(vm.MaSanPham))
                return BadRequest(new { message = "Mã sản phẩm đã tồn tại." });

            if (await _sanPhamRepository.ExistsByTenAsync(vm.TenSanPham))
                return BadRequest(new { message = "Tên sản phẩm đã tồn tại." });

            var loaiSanPham = await _loaiSanPhamRepository.GetByIdAsync(vm.LoaiSanPhamId);
            if (loaiSanPham == null)
                return BadRequest(new { message = "Loại sản phẩm không tồn tại." });   

            var donViTinh = await _donViTinhRepository.GetByIdAsync(vm.DonViTinhId); 
            if (donViTinh == null)
                return BadRequest(new { message = "Đơn vị tính không tồn tại." });

            var model = _mapper.Map<SanPham>(vm);
            var created = await _sanPhamRepository.CreateAsync(model);
            var createdVm = _mapper.Map<SanPhamVM>(created);

            return CreatedAtAction(nameof(GetSanPham), new { id = createdVm.Id }, createdVm);
        }

        // PUT: api/SanPhams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPham(int id, SanPhamUpdateVM vm)
        {
            if (id != vm.Id)
                return BadRequest(new { message = "Id không khớp với dữ liệu gửi lên." });

            if (await _sanPhamRepository.ExistsByMaAsync(vm.MaSanPham, vm.Id))
                return BadRequest(new { message = "Mã sản phẩm đã tồn tại." });

            if (await _sanPhamRepository.ExistsByTenAsync(vm.TenSanPham, vm.Id))
                return BadRequest(new { message = "Tên sản phẩm đã tồn tại." });

            var loaiSanPham = await _loaiSanPhamRepository.GetByIdAsync(vm.LoaiSanPhamId);
            if (loaiSanPham == null)
                return BadRequest(new { message = "Loại sản phẩm không tồn tại." });

            var donViTinh = await _donViTinhRepository.GetByIdAsync(vm.DonViTinhId);
            if (donViTinh == null)
                return BadRequest(new { message = "Đơn vị tính không tồn tại." });

            var model = _mapper.Map<SanPham>(vm);

            try
            {
                var updated = await _sanPhamRepository.UpdateAsync(model);
                var resultVm = _mapper.Map<SanPhamVM>(updated);
                return Ok(resultVm);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        // DELETE: api/SanPhams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            var deleted = await _sanPhamRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = "Không tìm thấy sản phẩm cần xoá." });

            return NoContent();
        }

        [HttpPost("bao-cao")]
        public async Task<IActionResult> BaoCaoXuatNhapTon([FromBody] BaoCaoXuatNhapTonFilter filter)
        {
            var data = await _sanPhamRepository.GetBaoCaoXuatNhapTonAsync(filter);
            return Ok(data);
        }
    }
}
