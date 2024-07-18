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
        private readonly ICheckListRepository _checkListRepository;

        public CheckListItemController(ICheckListItemRepository repository, ICheckListRepository checkListRepository)
        {
            _repository = repository;
            _checkListRepository = checkListRepository;
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
                return NotFound();
            }
            
            return Ok(checkGetById.ToCheckListItemDto());
        }
        
        [HttpPost("{checklistId:int}")]
        public async Task<IActionResult> Create([FromBody] CreateCheckListItemDto checkDto, [FromRoute] int checklistId)
        {
            var checklistExists = await _checkListRepository.ExistsAsync(checklistId);
            if (checklistExists == false)
            {
                return NotFound($"Checklist with id {checklistId} doesn't exists");
            }
            
            var checkListItemModel = checkDto.ToCheckListItemFromCreateDto(checklistId);
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
