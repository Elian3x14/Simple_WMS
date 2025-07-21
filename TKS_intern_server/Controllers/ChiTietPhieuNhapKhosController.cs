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

        // POST: api/ChiTietPhieuNhapKhos/{phieuNhapKhoId}
        [HttpPost("{phieuNhapKhoId}")]
        public async Task<IActionResult> PostListChiTietPhieuNhapKho([FromBody] List<ChiTietPhieuNhapKhoSaveVM> items, int phieuNhapKhoId)
        {
            if (items == null || !items.Any())
                return BadRequest(new { message = "Danh sách chi tiết phiếu nhập không được rỗng." });
            
            var phieuNhapKho = await _phieuNhapKhoRepository.GetByIdAsync(phieuNhapKhoId);
            if (phieuNhapKho == null)
                return BadRequest(new { message = "Phiếu nhập kho không tồn tại." });

            List<ChiTietPhieuNhapKho> model2Saves = new();
            SanPham? temp = default!;
            foreach (var item in items)
            {
                temp = await _sanPhamRepository.GetByIdAsync(item.SanPhamId);
                if (temp == null)
                    return BadRequest(new { message = $"Sản phẩm với ID {item.SanPhamId} không tồn tại." });

                model2Saves.Add(new ChiTietPhieuNhapKho()
                {
                    PhieuNhapKhoId = phieuNhapKhoId,
                    SanPhamId = item.SanPhamId,
                    SoLuongNhap = item.SoLuongNhap,
                    DonGiaNhap = item.DonGiaNhap,
                    SanPham = temp,
                    PhieuNhapKho = phieuNhapKho
                });
            }

            // Xóa toàn bộ chi tiết phiếu nhập kho cũ
            var existingDetails = await _repository.GetByPhieuNhapKhoIdAsync(phieuNhapKhoId);
            if (existingDetails.Any())
            {
                await _repository.DeleteByPhieuNhapKhoIdAsync(phieuNhapKhoId);
            }

            await _repository.AddRangeAsync(model2Saves);

            return Ok(new { message = "Lưu danh sách chi tiết phiếu nhập thành công." });
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
