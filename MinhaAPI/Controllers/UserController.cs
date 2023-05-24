using MinhaAPI.Entities;
using Microsoft.AspNetCore.Http;
using MinhaAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public UserController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetContas()
        {
            var contas = _context.Users.Where(x => !x.IsDeleted).ToList();
            return Ok(contas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetUserID(int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost("ContaCorrente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(Corrente corrente)
        {
            _context.Users.Add(corrente);
            return CreatedAtAction("GetUserId", new { id = corrente.Id }, corrente);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id, User input)
        {
            var userReturned = _context.Users.SingleOrDefault(d => d.Id == id);

            if (userReturned == null)
            {
                return NotFound();
            }

            userReturned.Update(input.Saldo);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var userRet = _context.Users.SingleOrDefault(d => d.Id == id);

            if (userRet == null)
            {
                return NotFound();
            }

            userRet.Delete();
            return NoContent();
        }

    }
}