using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKS_intern.Data;
using TKS_intern.Repositories.Interfaces;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.DonViTinhs;

namespace TKS_intern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonViTinhsController : ControllerBase
    {
        private readonly TKS_internContext _context;
        private readonly IDonViTinhRepository _donViTinhRepository;
        private readonly IMapper _mapper;

        public DonViTinhsController(TKS_internContext context, IMapper mapper, IDonViTinhRepository donViTinhRepository)
        {
            _context = context;
            _mapper = mapper;
            _donViTinhRepository = donViTinhRepository;
        }

        // GET: api/DonViTinhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonViTinhVM>>> GetDonViTinh()
        {
            var list = await _donViTinhRepository.GetAllAsync();
            var listMapped = _mapper.Map<IEnumerable<DonViTinhVM>>(list);
            return Ok(listMapped);

        }

        // GET: api/DonViTinhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonViTinhVM>> GetDonViTinh(int id)
        {
            var donViTinh = await _donViTinhRepository.GetByIdAsync(id);

            if (donViTinh == null)
            {
                return NotFound("Không tìm thấy đơn vị tính.");
            }
            var donViTinhVm = _mapper.Map<DonViTinhVM>(donViTinh);
            return donViTinhVm;
        }

        // PUT: api/DonViTinhs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonViTinh(int id, DonViTinhUpdateVM vm)
        {
            if (id != vm.Id)
            {
                return BadRequest(new { message = "Id không khớp với dữ liệu gửi lên." });
            }

            // Kiểm tra trùng tên (loại trừ chính bản ghi đang cập nhật)
            var isDuplicate = await _donViTinhRepository.ExistsByNameAsync(vm.TenDonViTinh, vm.Id);
            if (isDuplicate)
            {
                return BadRequest(new { message = "Tên đơn vị tính đã tồn tại." });
            }

            var model = _mapper.Map<DonViTinh>(vm);

            try
            {
                var updated = await _donViTinhRepository.UpdateAsync(model);
                var resultVm = _mapper.Map<DonViTinhVM>(updated);

                return Ok(resultVm);
            }
            catch (KeyNotFoundException e)
            {
                // Trường hợp không tìm thấy bản ghi
                return NotFound(new { message = e.Message });
            }
        }


        // POST: api/DonViTinhs
        [HttpPost]
        public async Task<ActionResult<DonViTinhVM>> PostDonViTinh(DonViTinhCreateVM donViTinhVm)
        {
            // Kiểm tra trùng tên
            var isExisted = await _donViTinhRepository.ExistsByNameAsync(donViTinhVm.TenDonViTinh);
            if (isExisted)
            {
                return BadRequest(new { message = "Tên đơn vị tính đã tồn tại." });
            }

            var model = _mapper.Map<DonViTinh>(donViTinhVm);
            var created = await _donViTinhRepository.CreateAsync(model);
            var createdVm = _mapper.Map<DonViTinhVM>(created);
            return CreatedAtAction("GetDonViTinh", new { id = createdVm.Id }, createdVm);
        }

        // DELETE: api/DonViTinhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonViTinh(int id)
        {
            var result = await _donViTinhRepository.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
