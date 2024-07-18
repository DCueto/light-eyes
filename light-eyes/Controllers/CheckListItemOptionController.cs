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

        public CheckListItemOptionController(ICheckListItemOptionRepository checkOptionRepository)
        {
            _repository = checkOptionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            var checkListOption = await _repository.GetAllAsync();
            var checkOptionDto = checkListOption.Select(x => x.ToCheckListItemOptionDto());
            return Ok(checkOptionDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var checkItemOption = await _repository.GetByIdAsync(id);
            if (checkItemOption == null)
            {
                return NotFound();
            }

            return Ok(checkItemOption.ToCheckListItemOptionDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCheckListItemOptionDto checkOptionDto)
        {
            var checkOptionModel = checkOptionDto.ToCheckListItemOptionFromCreateDto();
            await _repository.CreateAsync(checkOptionModel);
            return CreatedAtAction(nameof(GetById), new { id = checkOptionModel.CheckListItemOptionId }, checkOptionModel.ToCheckListItemOptionDto());
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody]  UpdateCheckListItemOptionDto updateCheckOptionDto)
        {
            var checkItemModel = await _repository.UpdateAsync(id, updateCheckOptionDto);
            if (checkItemModel == null)
            {
                return NotFound();
            }

            return Ok(checkItemModel.ToCheckListItemOptionDto());
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var checkOptionModel = await _repository.DeleteAsync(id);
            if (checkOptionModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}