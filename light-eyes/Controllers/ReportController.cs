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
        private readonly IReportRepository _repository;

        public ReportController(IReportRepository reportRepository)
        {
            _repository = reportRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var reportList = await _repository.GetAllAsync();
            var reportDto = reportList.Select(x => x.ToReportDto());
            return Ok(reportDto);
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