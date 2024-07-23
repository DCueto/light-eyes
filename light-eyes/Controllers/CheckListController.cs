using light_eyes.DTOs.Checklist;
using light_eyes.DTOs.CheckList;
using light_eyes.Interfaces;
using light_eyes.Mappers;
using light_eyes.Models;
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
        public async Task<ActionResult<List<CheckListDto>>> GetAll()
        {
            var checkList = await _checkListRepository.GetAllAsync();
            var checkDto = checkList.Select(x => x.ToCheckListDto());
            return Ok(checkDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CheckListDto>> GetById([FromRoute] int id)
        {
            var check = await _checkListRepository.GetByIdAsync(id);
            if (check == null)
            {
                return NotFound();
            }

            return Ok(check.ToCheckListDto());
        }

        [HttpPost]
        public async Task<ActionResult<CheckListDto>> Create([FromBody] CreateChecklistRequestDto checkDto)
        {
            var checkListModel = checkDto.ToCheckListFromCreateDto();
            var checkList = await _checkListRepository.CreateAsync(checkListModel);
            var checklistDto = checkList.ToCheckListDto();
            return CreatedAtAction(nameof(GetById), new { id = checkList.CheckListId }, checklistDto);
        }

        [HttpPost]
        public async Task<ActionResult<CheckList>> CreateByTransaction([FromBody] CheckListDto checkListDto)
        {
            try
            {
                var transactionChecklist = await _checkListRepository.CreateByTransactionAsync(checkListDto);
                return CreatedAtAction(nameof(GetById), new { id = transactionChecklist.CheckListId },
                    transactionChecklist);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
            
                
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<CheckListDto>> Update([FromRoute] int id,
            [FromBody] UpdateCheckListDto updateDto)
        {
            var checkListModel = updateDto.ToCheckListFromUpdateDto();
            var checkListUpdated = await _checkListRepository.UpdateAsync(id, checkListModel);

            if (checkListUpdated == null)
            {
                return NotFound();
            }

            return Ok(checkListUpdated.ToCheckListDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<CheckListDto>> Delete([FromRoute] int id)
        {
            var checkModel = await _checkListRepository.DeleteAsync(id);
            if (checkModel == null)
            {
                return NotFound();
            }

            return Ok(checkModel.ToCheckListDto());
        }
    }
}