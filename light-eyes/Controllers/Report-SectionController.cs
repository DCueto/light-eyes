using System.Collections.Specialized;
using light_eyes.Interfaces;
using light_eyes.Mappers;
using light_eyes.Models;
using light_eyes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace light_eyes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Report_SectionController : ControllerBase
    {
        private readonly IReport_SectionRepository _repository;
        private readonly IReportRepository _reportRepository;
        private readonly ISectionRepository _sectionRepository;

        public Report_SectionController(IReport_SectionRepository repository, IReportRepository reportRepository,
            ISectionRepository sectionRepository)
        {
            _repository = repository;
            _reportRepository = reportRepository;
            _sectionRepository = sectionRepository;
        }

        // [HttpGet]
        // public async Task<Bi> GetSectionsFromReport()
        // {
        //     var section = await _repository.GetSectionsFromReport();
        //     var sectionsDtos = section.Select(s => s.ToSectionDto());
        //     return Ok(sectionsDtos);
        // }
    }
}