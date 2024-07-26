using light_eyes.DTO.Report;
using light_eyes.Interfaces;
using light_eyes.Mappers;
using light_eyes.Models;
using light_eyes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace light_eyes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase 
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var reportList = await _reportRepository.GetAllAsync();
            var reportDto = reportList.Select(x => x.ToReportDto()).ToList();
            return Ok(reportDto);
        }

        [HttpPost("createByTransaction")]
        public async Task<ActionResult<Report>> CreateByTransaction([FromBody] CreateReportRequestDto createReportDto)
        {
            try
            {
                var report = createReportDto.ToReportFromCreateDto();
                var transactionReport = await _reportRepository.CreateByTransactionAsync(report);
                return Ok(transactionReport.ToReportDto()); // Change to CreatedAtAction actionResult method
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // [HttpGet("{id:int}")]
        // public async Task<IActionResult> GetById([FromRoute] int id)
        // {
        //     var report = await _repository.GetByIdAsync(id);
        //     if (report == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return Ok(report.ToReportDto());
        // }
        //
        //
        // [HttpDelete]
        // [Route("{id:int}")]
        // public async Task<IActionResult> Delete([FromRoute] int id)
        // {
        //     var reportModel = await _repository.DeleteAsync(id);
        //     if (reportModel == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return NoContent();
        // }
        
    }
}