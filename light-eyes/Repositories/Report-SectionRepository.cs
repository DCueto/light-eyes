using light_eyes.Data;
using light_eyes.Models;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Repositories;

public class ReportSectionRepository : IReport_SectionRepository
{
    private readonly AppDbContext _context;

    public ReportSectionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Section>> GetSectionsFromReport(Section sectionId, int id)
    {
        var reportSection = await _context.ReportSections.Where(rp => rp.SectionId == id)
            .Select(section => new Section
            {
                SectionId = section.SectionId,
                Name = section.Section.Name,
                Title = section.Section.Title,
                Content = section.Section.Content,
                Type = section.Section.Type,
                Language = section.Section.Language
            })
            .ToListAsync();
        return reportSection;
    }
}