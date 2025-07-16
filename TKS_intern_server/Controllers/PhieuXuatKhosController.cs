using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.BaoCaos;
using TKS_intern_shared.ViewModels.PhieuXuatKhos;

namespace TKS_intern_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuXuatKhosController : ControllerBase
    {
        private readonly IPhieuXuatKhoRepository _repository;
        private readonly IKhoRepository _khoRepository;
        private readonly INhaCungCapRepository _nhaCungCapRepository;
        private readonly IMapper _mapper;

        public PhieuXuatKhosController(
            IPhieuXuatKhoRepository repository,
            IKhoRepository khoRepository,
            INhaCungCapRepository nhaCungCapRepository,
            IMapper mapper)
        {
            _repository = repository;
            _khoRepository = khoRepository;
            _nhaCungCapRepository = nhaCungCapRepository;
            _mapper = mapper;
        }

        // GET: api/PhieuXuatKhos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhieuXuatKhoVM>>> GetAll()
        {
            var list = await _repository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<PhieuXuatKhoVM>>(list);
            return Ok(mapped);
        }

        // GET: api/PhieuXuatKhos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhieuXuatKhoVM>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound(new { message = "Không tìm thấy phiếu xuất kho." });

            return Ok(_mapper.Map<PhieuXuatKhoVM>(entity));
        }

        // POST: api/PhieuXuatKhos
        [HttpPost]
        public async Task<ActionResult<PhieuXuatKhoVM>> Create(PhieuXuatKhoCreateVM vm)
        {
            if (await _repository.ExistsBySoPhieuAsync(vm.SoPhieuXuatKho))
                return BadRequest(new { message = "Số phiếu xuất kho đã tồn tại." });

            if (await _khoRepository.GetByIdAsync(vm.KhoId) == null)
                return BadRequest(new { message = "Kho không tồn tại." });

            var model = _mapper.Map<PhieuXuatKho>(vm);
            var created = await _repository.CreateAsync(model);
            var createdVm = _mapper.Map<PhieuXuatKhoVM>(created);

            return CreatedAtAction(nameof(GetById), new { id = createdVm.Id }, createdVm);
        }

        // DELETE: api/PhieuXuatKhos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
                return NotFound(new { message = "Không tìm thấy phiếu xuất kho để xoá." });

            return NoContent();
        }

        [HttpPost("baocao")]
        public async Task<ActionResult<List<BaoCaoXuatHangVM>>> BaoCaoXuat([FromBody] BaoCaoXuatFilter filter)
        {
            var result = await _repository.GetBaoCaoXuatHangAsync(filter.TuNgay, filter.DenNgay);
            return Ok(result);
        }

    }
}
