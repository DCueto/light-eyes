using light_eyes.DTOs;
using light_eyes.Interfaces;
using light_eyes.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace light_eyes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository _repository;

        public SectionController(ISectionRepository sectionRepository)
        {
            _repository = sectionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSections()
        {
            var sectionList = await _repository.GetAllAsync();
            var sectionDto = sectionList.Select(x => x.ToSectionDto());
            return Ok(sectionDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var section = await _repository.GetByIdAsync(id);
            if (section == null)
            {
                return
                    NotFound();
            }

            return Ok(section.ToSectionDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSectionRequestDto sectionDto)
        {
            var sectionModel = sectionDto.ToSectionFromCreateDTO();
            await _repository.CreateAsync(sectionModel);
            return CreatedAtAction(nameof(GetById), new { id = sectionModel.SectionId }, sectionModel.ToSectionDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSectionRequestDto updateSectionDto)
        {
            var sectionModel = await _repository.UpdateAsync(id, updateSectionDto);
            if (sectionModel == null)
            {
                return NotFound();
            }

            return Ok(sectionModel.ToSectionDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var sectionModel = await _repository.DeleteAsync(id);
            if (sectionModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
