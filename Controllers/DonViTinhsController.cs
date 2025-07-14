using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKS_intern.Data;
using TKS_intern.Models;
using TKS_intern.Repositories.Interfaces;
using TKS_intern.ViewModels.DonViTinhs;

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
        public async Task<ActionResult<IEnumerable<DonViTinh>>> GetDonViTinh()
        {
            return await _context.DonViTinh.ToListAsync();
        }

        // GET: api/DonViTinhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonViTinh>> GetDonViTinh(int id)
        {
            var donViTinh = await _context.DonViTinh.FindAsync(id);

            if (donViTinh == null)
            {
                return NotFound();
            }

            return donViTinh;
        }

        // PUT: api/DonViTinhs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonViTinh(int id, DonViTinhVM donViTinh)
        {
            if (id != donViTinh.Id)
            {
                return BadRequest();
            }

            _context.Entry(donViTinh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonViTinhExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DonViTinhs
        [HttpPost]
        public async Task<ActionResult<DonViTinhVM>> PostDonViTinh(DonViTinhCreate donViTinhVm)
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
            var donViTinh = await _context.DonViTinh.FindAsync(id);
            if (donViTinh == null)
            {
                return NotFound();
            }

            _context.DonViTinh.Remove(donViTinh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonViTinhExists(int id)
        {
            return _context.DonViTinh.Any(e => e.Id == id);
        }
    }
}
