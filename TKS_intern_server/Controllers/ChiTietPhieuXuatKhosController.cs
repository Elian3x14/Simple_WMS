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

        [HttpPost("{phieuXuatId}")]
        public async Task<IActionResult> PostListChiTietPhieuXuatKho(
            [FromBody] List<ChiTietPhieuXuatKhoSaveVM> items,
            int phieuXuatId)
        {
            if (items == null || !items.Any())
                return BadRequest(new { message = "Danh sách chi tiết phiếu xuất không được rỗng." });

            // Kiểm tra tồn tại của phiếu xuất kho
            var phieuXuat = await _phieuXuatKhoRepository.GetByIdAsync(phieuXuatId);
            if (phieuXuat == null)
                return BadRequest(new { message = "Phiếu xuất kho không tồn tại." });

            // Kiểm tra tồn tại sản phẩm (có thể kiểm tra từng sản phẩm nếu cần)
            List<ChiTietPhieuXuatKho> model2Saves = new();
            SanPham? temp = default!;
            foreach (var item in items)
            {
                temp = await _sanPhamRepository.GetByIdAsync(item.SanPhamId);
                if (temp == null)
                    return BadRequest(new { message = $"Sản phẩm ID {item.SanPhamId} không tồn tại." });
                model2Saves.Add(new ChiTietPhieuXuatKho
                {
                    PhieuXuatKhoId = phieuXuatId,
                    SanPhamId = item.SanPhamId,
                    SoLuongXuat = item.SoLuongXuat,
                    DonGiaXuat = item.DonGiaXuat,
                    SanPham = temp,
                    PhieuXuatKho = phieuXuat
                });
            }

            // Xóa các bản ghi chi tiết phiếu xuất cũ
            await _repository.DeleteByPhieuXuatKhoIdAsync(phieuXuatId);
            // Thêm mới danh sách chi tiết
            await _repository.AddRangeAsync(model2Saves);

            return Ok(new { message = "Cập nhật chi tiết phiếu xuất thành công." });
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
