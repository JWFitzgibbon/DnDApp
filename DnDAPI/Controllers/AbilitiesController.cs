using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DnDAPI.Models;
using System.Net;

namespace DnDApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        private readonly RepositoryContext _context;
        protected ResponseHandler _response;

        public AbilitiesController(RepositoryContext context)
        {
            _context = context;
            _response = new ResponseHandler();
        }

        [HttpGet]
        public async Task<ActionResult<ResponseHandler>> GetAbilities()
        {
            try
            {
                _response.Result = await _context.Abilities.ToListAsync();
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ability>> GetAbility(int id)
        {
            if (_context.Abilities == null)
            {
                return NotFound();
            }
            var ability = await _context.Abilities.FindAsync(id);

            if (ability == null)
            {
                return NotFound();
            }

            return ability;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Ability>>> GetAbilitiesByName([FromQuery] string name)
        {
            if (_context.Abilities == null)
            {
                return NotFound();
            }
            return await _context.Abilities.Where(a => a.Name.StartsWith(name)).ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAbility(int id, Ability ability)
        {
            if (id != ability.AbilityId)
            {
                return BadRequest();
            }

            _context.Entry(ability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbilityExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Ability>> PostAbility(Ability ability)
        {
            if (_context.Abilities == null)
            {
                return Problem("Entity set 'RepositoryContext.Abilities'  is null.");
            }
            _context.Abilities.Add(ability);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbility", new { id = ability.AbilityId }, ability);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAbility(int id)
        {
            if (_context.Abilities == null)
            {
                return NotFound();
            }
            var ability = await _context.Abilities.FindAsync(id);
            if (ability == null)
            {
                return NotFound();
            }

            _context.Abilities.Remove(ability);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbilityExists(int id)
        {
            return (_context.Abilities?.Any(e => e.AbilityId == id)).GetValueOrDefault();
        }
    }
}
