using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.ChiTietPhieuXuatKhos;

namespace TKS_intern_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietPhieuXuatKhosController : ControllerBase
    {
        private readonly IChiTietPhieuXuatKhoRepository _repository;
        private readonly IPhieuXuatKhoRepository _phieuXuatKhoRepository;
        private readonly ISanPhamRepository _sanPhamRepository;
        private readonly IMapper _mapper;

        public ChiTietPhieuXuatKhosController(
            IChiTietPhieuXuatKhoRepository repository,
            IPhieuXuatKhoRepository phieuXuatKhoRepository,
            ISanPhamRepository sanPhamRepository,
            IMapper mapper)
        {
            _repository = repository;
            _phieuXuatKhoRepository = phieuXuatKhoRepository;
            _sanPhamRepository = sanPhamRepository;
            _mapper = mapper;
        }

        // GET: api/ChiTietPhieuXuatKhos/phieuXuatKho/5
        [HttpGet("phieuXuatKho/{phieuXuatKhoId}")]
        public async Task<ActionResult<IEnumerable<ChiTietPhieuXuatKhoVM>>> GetByPhieuXuatKhoId(int phieuXuatKhoId)
        {
            var list = await _repository.GetByPhieuXuatKhoIdAsync(phieuXuatKhoId);
            return Ok(_mapper.Map<IEnumerable<ChiTietPhieuXuatKhoVM>>(list));
        }

        // POST: api/ChiTietPhieuXuatKhos
        [HttpPost]
        public async Task<IActionResult> PostListChiTietPhieuXuatKho([FromBody] List<ChiTietPhieuXuatKhoSaveVM> items)
        {
            if (items == null || !items.Any())
                return BadRequest(new { message = "Danh sách chi tiết phiếu xuất không được rỗng." });

            var firstItem = items.First();

            if (await _sanPhamRepository.GetByIdAsync(firstItem.SanPhamId) == null)
                return BadRequest(new { message = "Sản phẩm không tồn tại." });

            if (await _phieuXuatKhoRepository.GetByIdAsync(firstItem.PhieuXuatKhoId) == null)
                return BadRequest(new { message = "Phiếu xuất kho không tồn tại." });

            var mapped = _mapper.Map<List<ChiTietPhieuXuatKho>>(items);
            await _repository.AddRangeAsync(mapped);

            return Ok(new { message = "Thêm chi tiết phiếu xuất thành công." });
        }

        // DELETE: api/ChiTietPhieuXuatKhos/phieuXuatKho/5
        [HttpDelete("phieuXuatKho/{phieuXuatKhoId}")]
        public async Task<IActionResult> DeleteByPhieuXuatKhoId(int phieuXuatKhoId)
        {
            var success = await _repository.DeleteByPhieuXuatKhoIdAsync(phieuXuatKhoId);

            if (!success)
                return NotFound(new { message = "Không tìm thấy chi tiết phiếu xuất để xoá." });

            return NoContent();
        }
    }
}
