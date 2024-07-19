using light_eyes.Data;
using light_eyes.DTOs;
using light_eyes.Interfaces;
using light_eyes.Models;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Repositories;

public class SectionRepository : ISectionRepository
{
    private readonly AppDbContext _context;

    public SectionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Section>> GetAllAsync()
    {
        return await _context.Section.ToListAsync();
    }

    public async Task<Section?> GetByIdAsync(int id)
    {
        return await _context.Section.FindAsync(id);
    }

    public async Task<Section> CreateAsync(Section sectionModel)
    {
        _context.Section.Add(sectionModel);
        await _context.SaveChangesAsync();
        return sectionModel;
    }

    public async Task<Section?> UpdateAsync(int id, UpdateSectionRequestDto updateSectionDto)
    {
        var existingSection = await _context.Section.FirstOrDefaultAsync(x => x.SectionId == id);
        if (existingSection == null)
        {
            return null;
        }

        existingSection.Name = updateSectionDto.Name;
        existingSection.Title = updateSectionDto.Title;
        existingSection.Content = updateSectionDto.Content;
        existingSection.Type = updateSectionDto.Type;
        existingSection.Language = updateSectionDto.Language;

        await _context.SaveChangesAsync();

        return existingSection;
    }

    public async Task<Section?> DeleteAsync(int id)
    {
        var sectionModel = await _context.Section.FirstOrDefaultAsync(x => x.SectionId == id);
        if (sectionModel == null)
        {
            return null;
        }

        _context.Section.Remove(sectionModel);
        await _context.SaveChangesAsync();
        return sectionModel;
    }
}