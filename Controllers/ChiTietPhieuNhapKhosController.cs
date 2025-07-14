using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.ChiTietPhieuNhapKhos;

namespace TKS_intern_shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietPhieuNhapKhosController : ControllerBase
    {
        private readonly IChiTietPhieuNhapKhoRepository _repository;
        private readonly IPhieuNhapKhoRepository _phieuNhapKhoRepository;
        private readonly ISanPhamRepository _sanPhamRepository;
        private readonly IMapper _mapper;

        public ChiTietPhieuNhapKhosController(
            IChiTietPhieuNhapKhoRepository repository,
            IPhieuNhapKhoRepository phieuNhapKhoRepository,
            ISanPhamRepository sanPhamRepository,
            IMapper mapper)
        {
            _repository = repository;
            _phieuNhapKhoRepository = phieuNhapKhoRepository;
            _sanPhamRepository = sanPhamRepository;
            _mapper = mapper;
        }

        // GET: api/ChiTietPhieuNhapKhos/phieuNhapKho/5
        [HttpGet("phieuNhapKho/{phieuNhapKhoId}")]
        public async Task<ActionResult<IEnumerable<ChiTietPhieuNhapKhoVM>>> GetByPhieuNhapKhoId(int phieuNhapKhoId)
        {
            var list = await _repository.GetByPhieuNhapKhoIdAsync(phieuNhapKhoId);
            return Ok(_mapper.Map<IEnumerable<ChiTietPhieuNhapKhoVM>>(list));
        }

        // POST: api/ChiTietPhieuNhapKhos
        [HttpPost]
        public async Task<IActionResult> PostListChiTietPhieuNhapKho([FromBody] List<ChiTietPhieuNhapKhoSaveVM> items)
        {
            // TODO: Validate thêm trạng thái của phiếu nhập kho và sản phẩm trước khi thêm chi tiết
            if (items == null || !items.Any())
                return BadRequest(new { message = "Danh sách chi tiết phiếu nhập không được rỗng." });
            var firstItem = items.First();
            if (await _sanPhamRepository.GetByIdAsync(firstItem.SanPhamId)== null)
                return BadRequest(new { message = "Sản phẩm không tồn tại." });
            
            if (await _phieuNhapKhoRepository.GetByIdAsync(firstItem.PhieuNhapKhoId) == null)   
                return BadRequest(new { message = "Phiếu nhập kho không tồn tại." });

            var mapped = _mapper.Map<List<ChiTietPhieuNhapKho>>(items);
            await _repository.AddRangeAsync(mapped);

            return Ok(new { message = "Thêm chi tiết phiếu nhập thành công." });
        }

        // DELETE: api/ChiTietPhieuNhapKhos/phieuNhapKho/5
        [HttpDelete("phieuNhapKho/{phieuNhapKhoId}")]
        public async Task<IActionResult> DeleteByPhieuNhapKhoId(int phieuNhapKhoId)
        {
            var success = await _repository.DeleteByPhieuNhapKhoIdAsync(phieuNhapKhoId);

            if (!success)
                return NotFound(new { message = "Không tìm thấy chi tiết phiếu nhập để xoá." });

            return NoContent();
        }
    }
}
