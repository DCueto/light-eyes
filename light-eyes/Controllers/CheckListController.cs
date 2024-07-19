using light_eyes.DTOs.CheckList;
using light_eyes.Interfaces;
using light_eyes.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace light_eyes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListController : ControllerBase
    {
        private readonly ICheckListRepository _checkListRepository;

        public CheckListController(ICheckListRepository checkListRepository)
        {
            _checkListRepository = checkListRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var checkList = await _checkListRepository.GetAllAsync();
            var checkDto = checkList.Select(x => x.ToCheckListDto());
            return Ok(checkDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var check = await _checkListRepository.GetByIdAsync(id);
            if (check == null)
            {
                return NotFound();
            }

            return Ok(check.ToCheckListDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCheckListDto checkDto)
        {
            var checkModel = checkDto.ToCheckListFromCreateDto();
            await _checkListRepository.CreatAsync(checkModel);
            return CreatedAtAction(nameof(GetById), new { id = checkModel.CheckListId }, checkModel.ToCheckListDto());

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCheckListDto updateDto)
        {
            var checkModel =await _checkListRepository.UpdateAsync(id , updateDto);
            if (checkModel == null)
            {
                return NotFound();
            }

            return Ok(checkModel.ToCheckListDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var checkModel = await _checkListRepository.DeleteAsync(id);
            if (checkModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        
    }
}
