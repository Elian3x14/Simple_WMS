using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.BaoCaos;
using TKS_intern_shared.ViewModels.PhieuNhapKhos;

namespace TKS_intern_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuNhapKhosController : ControllerBase
    {
        private readonly IPhieuNhapKhoRepository _repository;
        private readonly IKhoRepository _khoRepository;
        private readonly INhaCungCapRepository _nhaCungCapRepository;
        private readonly IMapper _mapper;

        public PhieuNhapKhosController(
            IPhieuNhapKhoRepository repository,
            IKhoRepository khoRepository,
            INhaCungCapRepository nhaCungCapRepository,
            IMapper mapper)
        {
            _repository = repository;
            _khoRepository = khoRepository;
            _nhaCungCapRepository = nhaCungCapRepository;
            _mapper = mapper;
        }

        // GET: api/PhieuNhapKhos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhieuNhapKhoVM>>> GetAll()
        {
            var list = await _repository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<PhieuNhapKhoVM>>(list);
            return Ok(mapped);
        }

        // GET: api/PhieuNhapKhos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuNhapKhoVM>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound(new { message = "Không tìm thấy phiếu nhập kho." });

            return Ok(_mapper.Map<PhieuNhapKhoVM>(entity));
        }

        // POST: api/PhieuNhapKhos
        [HttpPost]
        public async Task<ActionResult<PhieuNhapKhoVM>> Create(PhieuNhapKhoCreateVM vm)
        {
            if (await _repository.ExistsBySoPhieuAsync(vm.SoPhieuNhapKho))
                return BadRequest(new { message = "Số phiếu nhập kho đã tồn tại." });

            if (await _khoRepository.GetByIdAsync(vm.KhoId) == null)
                return BadRequest(new { message = "Kho không tồn tại." });

            if (await _nhaCungCapRepository.GetByIdAsync(vm.NhaCungCapId) == null)
                return BadRequest(new { message = "Nhà cung cấp không tồn tại." });

            var model = _mapper.Map<PhieuNhapKho>(vm);
            var created = await _repository.CreateAsync(model);
            var createdVm = _mapper.Map<PhieuNhapKhoVM>(created);

            return CreatedAtAction(nameof(GetById), new { id = createdVm.Id }, createdVm);
        }
        // PUT: api/PhieuNhapKhos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PhieuNhapKhoCreateVM vm)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { message = "Phiếu nhập kho không tồn tại." });

            // Kiểm tra trùng số phiếu (trừ chính bản thân nó)
            if (await _repository.ExistsBySoPhieuAsync(vm.SoPhieuNhapKho, excludeId: id))
                return BadRequest(new { message = "Số phiếu nhập kho đã tồn tại." });

            if (await _khoRepository.GetByIdAsync(vm.KhoId) == null)
                return BadRequest(new { message = "Kho không tồn tại." });

            if (await _nhaCungCapRepository.GetByIdAsync(vm.NhaCungCapId) == null)
                return BadRequest(new { message = "Nhà cung cấp không tồn tại." });

            // Map thông tin mới vào bản ghi cũ
            _mapper.Map(vm, existing);

            var updated = await _repository.UpdateAsync(existing);

            return Ok(updated);
        }

        // DELETE: api/PhieuNhapKhos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
                return NotFound(new { message = "Không tìm thấy phiếu nhập kho để xoá." });

            return NoContent();
        }

        [HttpPost("baocao")]
        public async Task<ActionResult<IEnumerable<BaoCaoNhapHangVM>>> BaoCaoChiTietNhap([FromBody] BaoCaoNhapFilter filter)
        {
            var result = await _repository.GetBaoCaoNhapHangAsync(filter.TuNgay, filter.DenNgay);
            return Ok(result);
        }
    }
}
