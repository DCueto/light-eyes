using light_eyes.Models;

namespace light_eyes.Repositories;

public interface IReport_SectionRepository
{
    Task<List<Section>> GetSectionsFromReport(Section sectionId, int id);
    // Task<Report_Section> CreateAsync();
    // Task<Report_Section?> DeleteReportSections();
}