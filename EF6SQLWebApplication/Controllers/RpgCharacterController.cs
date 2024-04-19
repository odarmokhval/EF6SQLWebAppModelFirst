using EF6SQLWebApplication.Data;
using EF6SQLWebApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EF6SQLWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RpgCharacterController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUnitOfWork _uow;

        public RpgCharacterController(DataContext context, IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
        }

        [HttpPost]
        public async Task<ActionResult<RpgCharacter>> AddCharacter(RpgCharacter character)
        {
            _uow.RpgCharacterRepository.AddCharacter(character);
            await _uow.SaveAsync();

            return Ok(character);
        }

        [HttpGet]
        public async Task<ActionResult<List<RpgCharacter>>> GetAllCharacters()
        {
            var characters = await _uow.RpgCharacterRepository.GetAllCharacters();
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RpgCharacter>> GetCharacter(int id)
        {
            var character = _uow.RpgCharacterRepository.GetCharacter(id);
            if (character == null)
            {
                return NotFound("Character not found");
            }
            return Ok(character);
        }
    }
}