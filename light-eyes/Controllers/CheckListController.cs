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
        

        [HttpPost("createByTransaction")]
        public async Task<ActionResult<CheckList>> CreateByTransaction([FromBody] CreateChecklistRequestDto checkListDto)
        {
            try
            {
                var checklist = checkListDto.ToCheckListFromCreateDto();
                var transactionChecklist = await _checkListRepository.CreateByTransactionAsync(checklist);
                return CreatedAtAction(nameof(GetById), new { id = transactionChecklist.CheckListId },
                    transactionChecklist);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        [HttpPut("updateByTransaction/{checkListId:int}")]
        public async Task<ActionResult<CheckListDto>> UpdateByTransaction([FromRoute] int checkListId, [FromBody] UpdateCheckListDto updateCheckListDto)
        {
            try
            {
                var existingCheckList = await _checkListRepository.GetByIdAsync(checkListId);

                if (existingCheckList == null)
                {
                    return NotFound();
                }
                
                // Update the existing checklist with incoming changes from UpdateCheckListDto
                var updatedCheckList = existingCheckList.UpdateChecklistFromDto(updateCheckListDto);
                var checkListUpdatedByTransaction = await _checkListRepository.UpdateByTransactionAsync(updatedCheckList, updateCheckListDto);

                if (checkListUpdatedByTransaction == null)
                    return StatusCode(500, "Has been an error through the transaction process");
                        
                return Ok(checkListUpdatedByTransaction.ToCheckListDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
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