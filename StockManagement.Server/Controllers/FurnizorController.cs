using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;
using StockManagement.Server.DTOs;
using StockManagement.Server.Entities;
using StockManagement.Server.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace StockManagement.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FurnizorController : ControllerBase
    {
        private readonly ISupplierRepository _furnizorRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public FurnizorController(ISupplierRepository furnizorRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _furnizorRepository = furnizorRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin, AngajatTier2, AngajatTier1, AngajatTier3")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetFurnizori()
        {
            var furnizori = await _furnizorRepository.GetSuppliersAsync();
            return Ok(_mapper.Map<IEnumerable<SupplierDTO>>(furnizori));
        }


        [Authorize(Roles = "Admin, AngajatTier2, AngajatTier1, AngajatTier3")]
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDTO>> GetFurnizor(int id)
        {
            var furnizor = await _furnizorRepository.GetSupplierAsync(id);
            if (furnizor == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SupplierDTO>(furnizor));
        }

         [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> AddFurnizor(SupplierDTO furnizorDTO)
        {
            var furnizor = _mapper.Map<Supplier>(furnizorDTO);
            await _furnizorRepository.AddSupplierAsync(furnizor);
            return CreatedAtAction(nameof(GetFurnizor), new { id = furnizor.SupplierId }, _mapper.Map<SupplierDTO>(furnizor));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<SupplierDTO>> UpdateFurnizor(int id, SupplierDTO furnizorDTO)
        {
            if (id != furnizorDTO.SupplierId)
            {
                return BadRequest();
            }
            try
            {
                var furnizor = _mapper.Map<Supplier>(furnizorDTO);
                await _furnizorRepository.UpdateSupplierAsync(furnizor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await FurnizorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(200);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SupplierDTO>> DeleteFurnizor(int id)
        {

            await _furnizorRepository.DeleteSupplierAsync(id);

            return Ok(200);
        }

        private async Task<bool> FurnizorExists(int id)
        {
            var furnizor = await _furnizorRepository.GetSupplierAsync(id);
            return furnizor != null;
        }

    }

    
}