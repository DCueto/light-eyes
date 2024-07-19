using light_eyes.DTOs;
using light_eyes.Models;

namespace light_eyes.Interfaces;

public interface ISectionRepository
{
    Task<List<Section>> GetAllAsync();
    Task<Section?> GetByIdAsync(int id);
    Task<Section> CreateAsync(Section reportModel);
    Task<Section?> UpdateAsync(int id, UpdateSectionRequestDto updateSectionDto);
    Task<Section?> DeleteAsync(int id);
}