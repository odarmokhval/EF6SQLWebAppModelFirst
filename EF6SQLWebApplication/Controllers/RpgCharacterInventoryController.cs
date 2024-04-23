using EF6SQLWebApplication.Data;
using EF6SQLWebApplication.Interfaces;
using EF6SQLWebApplication.Intergaces;
using EF6SQLWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF6SQLWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RpgCharacterInventoryController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RpgCharacterInventoryController(DataContext context, IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public async Task<ActionResult<RpgCharacterInventory>> AddItemToInventory(RpgCharacterInventory item)
        {
            _uow.RpgCharacterInventoryRepository.AddItemToInventory(item);
            await _uow.SaveAsync();

            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<List<RpgCharacterInventory>>> GetAllItems()
        {
            var items = await _uow.RpgCharacterInventoryRepository.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RpgCharacterInventory>> GetItem(int id)
        {
            var item = _uow.RpgCharacterInventoryRepository.GetItem(id);
            if (item == null)
            {
                return NotFound("Item not found");
            }
            return Ok(item);
        }
    }
}