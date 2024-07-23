using light_eyes.DTOs.CheckListItemOption;
using light_eyes.Interfaces;
using light_eyes.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace light_eyes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListItemOptionController : ControllerBase
    {
        private readonly ICheckListItemOptionRepository _repository;
        private readonly ICheckListItemRepository _checkListItemRepository;

        public CheckListItemOptionController(ICheckListItemOptionRepository checkOptionRepository,
            ICheckListItemRepository checkListItemRepository)
        {
            _repository = checkOptionRepository;
            _checkListItemRepository = checkListItemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CheckListItemOptionDto>>> GetAllList()
        {
            var checkListOption = await _repository.GetAllAsync();
            var checkOptionDto = checkListOption.Select(x => x.ToCheckListItemOptionDto());
            return Ok(checkOptionDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CheckListItemOptionDto>> GetById(int id)
        {
            var checkItemOption = await _repository.GetByIdAsync(id);
            if (checkItemOption == null)
            {
                return NotFound();
            }

            return Ok(checkItemOption.ToCheckListItemOptionDto());
        }

        [HttpPost("{checkListItemId:int}")]
        public async Task<ActionResult<CheckListItemOptionDto>> Create(
            [FromBody] CreateCheckListItemOptionDto checkOptionDto, [FromRoute] int checkListItemId)
        {
            var checkListItemExists = await _checkListItemRepository.ExistsAsync(checkListItemId);
            if (checkListItemExists == false)
            {
                return NotFound();
            }

            var checkOptionModel = checkOptionDto.ToCheckListItemOptionFromCreateDto(checkListItemId);
            await _repository.CreateAsync(checkOptionModel);
            return CreatedAtAction(nameof(GetById), new { id = checkOptionModel.CheckListItemOptionId },
                checkOptionModel.ToCheckListItemOptionDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<CheckListItemOptionDto>> Update([FromRoute] int id,
            [FromBody] UpdateCheckListItemOptionDto updateCheckOptionDto)
        {
            var checkListItemOptionModel = updateCheckOptionDto.ToCheckListFromUpdateDto();
            var checkItemModel = await _repository.UpdateAsync(id, checkListItemOptionModel);
            if (checkItemModel == null)
            {
                return NotFound();
            }

            return Ok(checkItemModel.ToCheckListItemOptionDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<CheckListItemOptionDto>> Delete([FromRoute] int id)
        {
            var checkOptionModel = await _repository.DeleteAsync(id);
            if (checkOptionModel == null)
            {
                return NotFound();
            }

            return Ok(checkOptionModel.ToCheckListItemOptionDto());
        }
    }
}