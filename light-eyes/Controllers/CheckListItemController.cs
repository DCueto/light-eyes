using light_eyes.DTOs.CheckListItemDto;
using light_eyes.Interfaces;
using light_eyes.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace light_eyes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListItemController : ControllerBase
    {
        private readonly ICheckListItemRepository _repository;

        public CheckListItemController(ICheckListItemRepository checkListItemRepository)
        {
            _repository = checkListItemRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllSections()
        {
            var checkList = await _repository.GetAllAsync();
            var checkDto = checkList.Select(x => x.ToCheckListItemDto());
            return Ok(checkDto);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var checkGetById = await _repository.GetByIdAsync(id);
            if (checkGetById == null)
            {
                return
                    NotFound();
            }

            return Ok(checkGetById.ToCheckListItemDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCheckListItemDto checkDto)
        {
            var checkListItemModel = checkDto.ToCheckListItemFromCreateDto();
            await _repository.CreateAsync(checkListItemModel);
            return CreatedAtAction(nameof(GetById), new { id = checkListItemModel.CheckListItemId }, checkListItemModel.ToCheckListItemDto());
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCheckListItemDto updateCheckListItemDto)
        {
            var checkListItemModel = await _repository.UpdateAsync(id, updateCheckListItemDto);
            if (checkListItemModel == null)
            {
                return NotFound();
            }

            return Ok(checkListItemModel.ToCheckListItemDto());
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var checkListItemModel = await _repository.DeleteAsync(id);
            if (checkListItemModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
